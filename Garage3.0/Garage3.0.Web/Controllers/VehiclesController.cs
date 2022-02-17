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
using AutoMapper;
using Garage3._0.Web.Models.ViewModels;

namespace Garage3._0.Web.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var model = _mapper.ProjectTo<VehicleIndexViewModel>(_context.VehicleEntity)
                .OrderBy(s => s.Id)
                .Take(10);
            return View(await model.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleEntity = await _context.VehicleEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleEntity == null)
            {
                return NotFound();
            }

            return View(vehicleEntity);
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
        public async Task<IActionResult> Create([Bind("Id,RegNo,Brand,Model,VehicleType,Member,Color")] VehicleEntity vehicleEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleEntity);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleEntity = await _context.VehicleEntity.FindAsync(id);
            if (vehicleEntity == null)
            {
                return NotFound();
            }
            return View(vehicleEntity);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNo,Brand,Model,VehicleType,Member,Color")] VehicleEntity vehicleEntity)
        {
            if (id != vehicleEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleEntityExists(vehicleEntity.Id))
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
            return View(vehicleEntity);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleEntity = await _context.VehicleEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleEntity == null)
            {
                return NotFound();
            }

            return View(vehicleEntity);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleEntity = await _context.VehicleEntity.FindAsync(id);
            _context.VehicleEntity.Remove(vehicleEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleEntityExists(int id)
        {
            return _context.VehicleEntity.Any(e => e.Id == id);
        }
    }
}
