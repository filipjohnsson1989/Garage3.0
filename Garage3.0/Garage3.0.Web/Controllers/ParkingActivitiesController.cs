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

namespace Garage3._0.Web.Controllers;

public class ParkingActivitiesController : Controller
{
    private readonly GarageContext _context;
    private readonly IMapper _mapper;


    public ParkingActivitiesController(GarageContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

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
            .OrderBy(parkingActivity => !parkingActivity.CheckOut.HasValue)
            .ThenBy(parkingActivity => parkingActivity.Id);
        //.Take(10);
        return View(await model.ToListAsync());
    }

    // GET: ParkingActivities/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var parkingActivity = await _context.ParkingActivities
            .Include(p => p.ParkingSpot)
            .Include(p => p.Vehicle)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (parkingActivity == null)
        {
            return NotFound();
        }

        return View(parkingActivity);
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

    // GET: ParkingActivities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var parkingActivity = await _context.ParkingActivities.FindAsync(id);
        if (parkingActivity == null)
        {
            return NotFound();
        }
        ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "Id", "Id", parkingActivity.ParkingSpotId);
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", parkingActivity.VehicleId);
        return View(parkingActivity);
    }

    // POST: ParkingActivities/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CheckIn,CheckOut,ParkingCost,VehicleId,ParkingSpotId")] ParkingActivityEntity parkingActivity)
    {
        if (id != parkingActivity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(parkingActivity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingActivityExists(parkingActivity.Id))
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
        ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "Id", "Id", parkingActivity.ParkingSpotId);
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", parkingActivity.VehicleId);
        return View(parkingActivity);
    }

    // GET: ParkingActivities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var parkingActivity = await _context.ParkingActivities
            .Include(p => p.ParkingSpot)
            .Include(p => p.Vehicle)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (parkingActivity == null)
        {
            return NotFound();
        }

        return View(parkingActivity);
    }

    // POST: ParkingActivities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var parkingActivity = await _context.ParkingActivities.FindAsync(id);
        _context.ParkingActivities.Remove(parkingActivity);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ParkingActivityExists(int id)
    {
        return _context.ParkingActivities.Any(e => e.Id == id);
    }
}
