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
    public class ProbkisController : Controller
    {
        private readonly ProbkiDb _context;

        public ProbkisController(ProbkiDb context)
        {
            _context = context;
        }

        // GET: Probkis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Probka.ToListAsync());
        }

        // GET: Probkis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probki = await _context.Probka
                .FirstOrDefaultAsync(m => m.IdBadania == id);
            if (probki == null)
            {
                return NotFound();
            }

            return View(probki);
        }

        // GET: Probkis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Probkis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBadania,Nazwa_Probki,Ilosc_Pojemnikow,Waga_Probek,zbadane")] Probki probki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(probki);
        }

        // GET: Probkis/Edit/5
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
            return View(probki);
        }

        // POST: Probkis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBadania,Nazwa_Probki,Ilosc_Pojemnikow,Waga_Probek,zbadane")] Probki probki)
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
            return View(probki);
        }

        // GET: Probkis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probki = await _context.Probka
                .FirstOrDefaultAsync(m => m.IdBadania == id);
            if (probki == null)
            {
                return NotFound();
            }

            return View(probki);
        }

        // POST: Probkis/Delete/5
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
