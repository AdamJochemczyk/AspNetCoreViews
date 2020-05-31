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
    public class LabsController : Controller
    {
        private readonly ProbkiDb _context;

        public LabsController(ProbkiDb context)
        {
            _context = context;
        }

        // GET: Labs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labs
                .Include(g=>g.Probki)
                .ToListAsync());
        }

        // GET: Labs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs
                .FirstOrDefaultAsync(m => m.IDLAB == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // GET: Labs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDLAB,NazwaLab,iloscPracownikow")] Lab lab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lab);
        }

        // GET: Labs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs.FindAsync(id);
            if (lab == null)
            {
                return NotFound();
            }
            return View(lab);
        }

        // POST: Labs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDLAB,NazwaLab,iloscPracownikow")] Lab lab)
        {
            if (id != lab.IDLAB)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabExists(lab.IDLAB))
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
            return View(lab);
        }

        // GET: Labs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs
                .FirstOrDefaultAsync(m => m.IDLAB == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // POST: Labs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lab = await _context.Labs.FindAsync(id);
            _context.Labs.Remove(lab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabExists(int id)
        {
            return _context.Labs.Any(e => e.IDLAB == id);
        }
    }
}
