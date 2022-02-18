#nullable disable
using Microsoft.AspNetCore.Mvc;
using Garage3._0.Web.Data;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Controllers;

public class VehicleTypesController : Controller
{
    private readonly GarageContext _context;

    public VehicleTypesController(GarageContext context)
    {
        _context = context;
    }

    // GET: VehicleTypeEntities
    public async Task<IActionResult> Index()
    {
        return View(await _context.VehicleTypes.ToListAsync());
    }

    // GET: VehicleTypeEntities/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicleType = await _context.VehicleTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehicleType == null)
        {
            return NotFound();
        }

        return View(vehicleType);
    }

    // GET: VehicleTypeEntities/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: VehicleTypeEntities/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,VehicleTypes")] VehicleTypeEntity vehicleType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vehicleType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vehicleType);
    }

    // GET: VehicleTypeEntities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicleType = await _context.VehicleTypes.FindAsync(id);
        if (vehicleType == null)
        {
            return NotFound();
        }
        return View(vehicleType);
    }

    // POST: VehicleTypeEntities/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleTypes")] VehicleTypeEntity vehicleType)
    {
        if (id != vehicleType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vehicleType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(vehicleType.Id))
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
        return View(vehicleType);
    }

    // GET: VehicleTypeEntities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicleType = await _context.VehicleTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehicleType == null)
        {
            return NotFound();
        }

        return View(vehicleType);
    }

    // POST: VehicleTypeEntities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var vehicleType = await _context.VehicleTypes.FindAsync(id);
        _context.VehicleTypes.Remove(vehicleType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VehicleTypeExists(int id)
    {
        return _context.VehicleTypes.Any(e => e.Id == id);
    }
}
