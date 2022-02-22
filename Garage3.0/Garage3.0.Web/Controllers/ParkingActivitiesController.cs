#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Data;
using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Models.ViewModels;
using AutoMapper;
using Garage3._0.Web.Common;

namespace Garage3._0.Web.Controllers;

public class ParkingActivitiesController : Controller
{
    private readonly GarageContext _context;
    private readonly IMapper _mapper;

    private readonly IConfiguration _config;
    private readonly double _parkingHourlyCost;

    public ParkingActivitiesController(GarageContext context, IMapper mapper, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;

        _config = config;

        if (double.TryParse(_config["Garage:HourlyCarge"], out double timeRate))
            _parkingHourlyCost = timeRate;
        else
            _parkingHourlyCost = 0.0;

    }

    // GET: ParkingActivities
    public async Task<IActionResult> Index()
    {


        var model = _mapper.ProjectTo<ParkingActivityIndexViewModel>(_context.ParkingActivities
            .Include(parkingActivitie => parkingActivitie.ParkingSpot)
            .Include(parkingActivities => parkingActivities.Vehicle)
            .ThenInclude(vehicle => vehicle.Member)
            .Include(parkingActivities => parkingActivities.Vehicle)
            .ThenInclude(vehicle => vehicle.VehicleType))
            .OrderBy(parkingActivity => parkingActivity.CheckOut.HasValue)
            .ThenBy(parkingActivity => parkingActivity.Id);
        //.Take(10);
        return View(await model.ToListAsync());
    }


    // GET: ParkingActivities/CheckIn
    public IActionResult CheckIn()
    {
        //ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "Id", "Id");
        //ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id");
        return View();
    }

    // POST: ParkingActivities/CheckIn
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckIn([Bind("Id, ParkingSpot, Vehicle")] ParkingActivityCheckInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var parkingSpotEntity = _context.ParkingSpots.FirstOrDefault(parkingSpot => parkingSpot.Id == viewModel.ParkingSpot.Id);
            var vehicleEntity = _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == viewModel.Vehicle.Id);

            var parkingActivityEntity = _mapper.Map<ParkingActivityEntity>(viewModel);
            parkingActivityEntity.ParkingSpot = parkingSpotEntity;
            parkingActivityEntity.Vehicle = vehicleEntity;
            parkingActivityEntity.CheckIn = DateTime.Now;

            await _context.AddAsync(parkingActivityEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "Id", "Id", viewModel.ParkingSpotId);
        //ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", viewModel.VehicleId);
        return View(viewModel);
    }


    // GET: ParkingActivities/CheckOut/5
    public async Task<IActionResult> CheckOut(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var parkingActivityEntity = await _context.ParkingActivities
            .Include(parkingActivitie => parkingActivitie.ParkingSpot)
            .Include(parkingActivities => parkingActivities.Vehicle)
            .ThenInclude(vehicle => vehicle.Member)
            .Include(parkingActivities => parkingActivities.Vehicle)
            .ThenInclude(vehicle => vehicle.VehicleType)
            .FirstOrDefaultAsync(m => m.Id == id);



        if (parkingActivityEntity == null)
        {
            return NotFound();
        }
        var viewModel = _mapper.Map<ParkingActivityCheckOutViewModel>(parkingActivityEntity);
        viewModel.HourlyCost = _parkingHourlyCost;

        return View(viewModel);
    }

    // POST: ParkingActivities/CheckOut/5
    [HttpPost, ActionName("CheckOut")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckOutConfirmed(int id)
    {
        var parkingActivity = await _context.ParkingActivities.FindAsync(id);
        parkingActivity.CheckOut = DateTime.Now;
        parkingActivity.ParkingCost = Util.ParkingTimeCost(parkingActivity.CheckIn, (DateTime)parkingActivity.CheckOut, _parkingHourlyCost);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ParkingActivityExists(int id)
    {
        return _context.ParkingActivities.Any(e => e.Id == id);
    }
}
