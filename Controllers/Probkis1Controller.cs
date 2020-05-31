using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zaj9.Models;

namespace zaj9.Controllers
{
    public class Probkis1Controller : Controller
    {
        private readonly ProbkiDb _context;

        public Probkis1Controller(ProbkiDb context)
        {
            _context = context;
        }

        // GET: Probkis1
        public async Task<IActionResult> Index()
        {
            var probkiDb = _context.Probka.Include(p => p.Lab);
            return View(await probkiDb.ToListAsync());
        }

        // GET: Probkis1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probki = await _context.Probka
                .Include(p => p.Lab)
                .FirstOrDefaultAsync(m => m.IdBadania == id);
            if (probki == null)
            {
                return NotFound();
            }

            return View(probki);
        }

        // GET: Probkis1/Create
        public IActionResult Create()
        {
            ViewData["FkLab"] = new SelectList(_context.Labs, "IDLAB", "NazwaLab");
            return View();
        }

        // POST: Probkis1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBadania,Nazwa_Probki,Ilosc_Pojemnikow,Waga_Probek,zbadane,Kosztbadania,FkLab")] Probki probki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkLab"] = new SelectList(_context.Labs, "IDLAB", "NazwaLab", probki.FkLab);
            return View(probki);
        }

        // GET: Probkis1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probki = await _context.Probka.FindAsync(id);
            if (probki == null)
            {
                return NotFound();
            }
            ViewData["FkLab"] = new SelectList(_context.Labs, "IDLAB", "NazwaLab", probki.FkLab);
            return View(probki);
        }

        // POST: Probkis1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBadania,Nazwa_Probki,Ilosc_Pojemnikow,Waga_Probek,zbadane,Kosztbadania,FkLab")] Probki probki)
        {
            if (id != probki.IdBadania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbkiExists(probki.IdBadania))
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
            ViewData["FkLab"] = new SelectList(_context.Labs, "IDLAB", "NazwaLab", probki.FkLab);
            return View(probki);
        }

        // GET: Probkis1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probki = await _context.Probka
                .Include(p => p.Lab)
                .FirstOrDefaultAsync(m => m.IdBadania == id);
            if (probki == null)
            {
                return NotFound();
            }

            return View(probki);
        }

        // POST: Probkis1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var probki = await _context.Probka.FindAsync(id);
            _context.Probka.Remove(probki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbkiExists(int id)
        {
            return _context.Probka.Any(e => e.IdBadania == id);
        }
    }
}
