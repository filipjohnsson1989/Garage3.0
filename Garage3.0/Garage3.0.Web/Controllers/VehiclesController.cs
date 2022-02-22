#nullable disable
using Microsoft.AspNetCore.Mvc;
using Garage3._0.Web.Data;
using Garage3._0.Web.Models.Entities;
using AutoMapper;
using Garage3._0.Web.Models.ViewModels;

namespace Garage3._0.Web.Controllers;

public class VehiclesController : Controller
{
    private readonly GarageContext _context;
    private readonly IMapper _mapper;

    public VehiclesController(GarageContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: Vehicles
    public async Task<IActionResult> Index(string? searchString)
    {
        var model = _mapper.ProjectTo<VehicleViewModel>(_context.Vehicles.Where(vehicle=> (searchString == null || vehicle.RegNo.Contains(searchString))))
            .OrderBy(s => s.Id);
        //.Take(10);
        return View(await model.ToListAsync());
    }

    [HttpPost]
    public string Index(FormCollection fc, string searchString)
    {
        return "<h3> From [HttpPost]Index: filter from: " + searchString +"</h3>";
    }

    // GET: Vehicles/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicleEntity = await _context.Vehicles
            .Include(vehicle => vehicle.Member)
            .Include(vehicle => vehicle.VehicleType)
            .FirstOrDefaultAsync(vehicle => vehicle.Id == id);
        if (vehicleEntity == null)
        {
            return NotFound();
        }

        var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleEntity);


        return View(vehicleViewModel);
    }

    // GET: Vehicles/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Vehicles/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Member,VehicleType,RegNo,Brand,Model,Color")] VehicleCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var vehicleTypeEntity = _context.VehicleTypes.FirstOrDefault(vehicleType => vehicleType.Id == viewModel.VehicleType.Id);
            var memberEntity = _context.Members.FirstOrDefault(member => member.Id == viewModel.Member.Id);

            var vehicleEntity = _mapper.Map<VehicleEntity>(viewModel);
            vehicleEntity.VehicleType = vehicleTypeEntity;
            vehicleEntity.Member = memberEntity;

            await _context.AddAsync(vehicleEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }

    // GET: Vehicles/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicleEntity = await _context.Vehicles
            .Include(vehicle => vehicle.Member)
            .Include(vehicle => vehicle.VehicleType)
            .FirstOrDefaultAsync(vehicle => vehicle.Id == id);


        if (vehicleEntity == null)
        {
            return NotFound();
        }

        var vehicleViewModel = _mapper.Map<VehicleEditViewModel>(vehicleEntity);

        return View(vehicleViewModel);
    }

    // POST: Vehicles/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Member,VehicleType,RegNo,Brand,Model,Color")] VehicleEditViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var vehicleTypeEntity = _context.VehicleTypes.FirstOrDefault(vehicleType => vehicleType.Id == viewModel.VehicleType.Id);
                var memberEntity = _context.Members.FirstOrDefault(member => member.Id == viewModel.Member.Id);

                var vehicleEntity = _mapper.Map<VehicleEntity>(viewModel);
                vehicleEntity.VehicleType = vehicleTypeEntity;
                vehicleEntity.Member = memberEntity;

                _context.Update(vehicleEntity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleEntityExists(viewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(viewModel);
    }

    // GET: Vehicles/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicleEntity = await _context.Vehicles
            .Include(vehicle => vehicle.Member)
            .Include(vehicle => vehicle.VehicleType)
            .FirstOrDefaultAsync(vehicle => vehicle.Id == id);

        if (vehicleEntity == null)
        {
            return NotFound();
        }

        var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleEntity);

        return View(vehicleViewModel);
    }

    // POST: Vehicles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var vehicleEntity = await _context.Vehicles.FindAsync(id);
        _context.Vehicles.Remove(vehicleEntity);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Search(string term)
    {
        var entities = await _context.Vehicles
             .Where(vehicle => vehicle.RegNo.Contains(term))
             .Include(vehicle => vehicle.Member)
             .Include(vehicle => vehicle.VehicleType)
             .Where(vehicle => 
             (
                !vehicle.ParkingActivitys.Where(parkingActivity=> !parkingActivity.CheckOut.HasValue).Any())
             )
             .ToListAsync();

        var viewModel=_mapper.Map<List<VehicleViewModel>>(entities);
        return Json(viewModel);

    }

    private bool VehicleEntityExists(int id)
    {
        return _context.Vehicles.Any(e => e.Id == id);
    }
}
