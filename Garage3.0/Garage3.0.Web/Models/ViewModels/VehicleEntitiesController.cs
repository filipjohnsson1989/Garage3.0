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
    public class VehicleEntitiesController : Controller
    {
        private readonly GarageContext _context;

        public VehicleEntitiesController(GarageContext context)
        {
            _context = context;
        }

        // GET: VehicleEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleEntities.ToListAsync());
        }

        // GET: VehicleEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleEntities = await _context.VehicleEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleEntities == null)
            {
                return NotFound();
            }

            return View(vehicleEntities);
        }

        // GET: VehicleEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleTypes")] VehicleEntities vehicleEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleEntities);
        }

        // GET: VehicleEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleEntities = await _context.VehicleEntities.FindAsync(id);
            if (vehicleEntities == null)
            {
                return NotFound();
            }
            return View(vehicleEntities);
        }

        // POST: VehicleEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleTypes")] VehicleEntities vehicleEntities)
        {
            if (id != vehicleEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleEntitiesExists(vehicleEntities.Id))
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
            return View(vehicleEntities);
        }

        // GET: VehicleEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleEntities = await _context.VehicleEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleEntities == null)
            {
                return NotFound();
            }

            return View(vehicleEntities);
        }

        // POST: VehicleEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleEntities = await _context.VehicleEntities.FindAsync(id);
            _context.VehicleEntities.Remove(vehicleEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleEntitiesExists(int id)
        {
            return _context.VehicleEntities.Any(e => e.Id == id);
        }
    }
}
