﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Data;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly GarageContext _context;

        public MembersController(GarageContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.MemberEntity.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEntity = await _context.MemberEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberEntity == null)
            {
                return NotFound();
            }

            return View(memberEntity);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PersonNr,Email")] MemberEntity memberEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberEntity);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEntity = await _context.MemberEntity.FindAsync(id);
            if (memberEntity == null)
            {
                return NotFound();
            }
            return View(memberEntity);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PersonNr,Email")] MemberEntity memberEntity)
        {
            if (id != memberEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberEntityExists(memberEntity.Id))
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
            return View(memberEntity);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEntity = await _context.MemberEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberEntity == null)
            {
                return NotFound();
            }

            return View(memberEntity);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberEntity = await _context.MemberEntity.FindAsync(id);
            _context.MemberEntity.Remove(memberEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberEntityExists(int id)
        {
            return _context.MemberEntity.Any(e => e.Id == id);
        }
    }
}
