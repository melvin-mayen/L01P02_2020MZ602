using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020MZ602.Models;

namespace L01P02_2020MZ602.Controllers
{
    public class facultadesController : Controller
    {
        private readonly notasDbContext _context;

        public facultadesController(notasDbContext context)
        {
            _context = context;
        }

        // GET: facultades
        public async Task<IActionResult> Index()
        {
            return View(await _context.facultades.ToListAsync());
        }

        // GET: facultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultades = await _context.facultades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultades == null)
            {
                return NotFound();
            }

            return View(facultades);
        }

        // GET: facultades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: facultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,facultad")] facultades facultades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultades);
        }

        // GET: facultades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultades = await _context.facultades.FindAsync(id);
            if (facultades == null)
            {
                return NotFound();
            }
            return View(facultades);
        }

        // POST: facultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,facultad")] facultades facultades)
        {
            if (id != facultades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!facultadesExists(facultades.Id))
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
            return View(facultades);
        }

        // GET: facultades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultades = await _context.facultades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultades == null)
            {
                return NotFound();
            }

            return View(facultades);
        }

        // POST: facultades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultades = await _context.facultades.FindAsync(id);
            if (facultades != null)
            {
                _context.facultades.Remove(facultades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool facultadesExists(int id)
        {
            return _context.facultades.Any(e => e.Id == id);
        }
    }
}
