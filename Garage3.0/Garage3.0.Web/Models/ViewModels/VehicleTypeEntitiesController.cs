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

namespace Garage3._0.Web.Models.ViewModels
{
    public class VehicleTypeEntitiesController : Controller
    {
        private readonly GarageContext _context;

        public VehicleTypeEntitiesController(GarageContext context)
        {
            _context = context;
        }

        // GET: VehicleTypeEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleTypeEntities.ToListAsync());
        }

        // GET: VehicleTypeEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleTypeEntities = await _context.VehicleTypeEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleTypeEntities == null)
            {
                return NotFound();
            }

            return View(vehicleTypeEntities);
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
        public async Task<IActionResult> Create([Bind("Id,VehicleTypes")] VehicleTypeEntities vehicleTypeEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleTypeEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleTypeEntities);
        }

        // GET: VehicleTypeEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleTypeEntities = await _context.VehicleTypeEntities.FindAsync(id);
            if (vehicleTypeEntities == null)
            {
                return NotFound();
            }
            return View(vehicleTypeEntities);
        }

        // POST: VehicleTypeEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleTypes")] VehicleTypeEntities vehicleTypeEntities)
        {
            if (id != vehicleTypeEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleTypeEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeEntitiesExists(vehicleTypeEntities.Id))
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
            return View(vehicleTypeEntities);
        }

        // GET: VehicleTypeEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleTypeEntities = await _context.VehicleTypeEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleTypeEntities == null)
            {
                return NotFound();
            }

            return View(vehicleTypeEntities);
        }

        // POST: VehicleTypeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleTypeEntities = await _context.VehicleTypeEntities.FindAsync(id);
            _context.VehicleTypeEntities.Remove(vehicleTypeEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleTypeEntitiesExists(int id)
        {
            return _context.VehicleTypeEntities.Any(e => e.Id == id);
        }
    }
}
