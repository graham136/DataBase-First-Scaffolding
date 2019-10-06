using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseFirst.Models;

namespace DataBaseFirst.Controllers
{
    public class SuspensionsController : Controller
    {
        private readonly TestDBContext _context;

        public SuspensionsController(TestDBContext context)
        {
            _context = context;
        }

        // GET: Suspensions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suspension.ToListAsync());
        }

        // GET: Suspensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suspension = await _context.Suspension
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suspension == null)
            {
                return NotFound();
            }

            return View(suspension);
        }

        // GET: Suspensions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suspensions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname")] Suspension suspension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suspension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suspension);
        }

        // GET: Suspensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suspension = await _context.Suspension.FindAsync(id);
            if (suspension == null)
            {
                return NotFound();
            }
            return View(suspension);
        }

        // POST: Suspensions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname")] Suspension suspension)
        {
            if (id != suspension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suspension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuspensionExists(suspension.Id))
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
            return View(suspension);
        }

        // GET: Suspensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suspension = await _context.Suspension
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suspension == null)
            {
                return NotFound();
            }

            return View(suspension);
        }

        // POST: Suspensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suspension = await _context.Suspension.FindAsync(id);
            _context.Suspension.Remove(suspension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuspensionExists(int id)
        {
            return _context.Suspension.Any(e => e.Id == id);
        }
    }
}
