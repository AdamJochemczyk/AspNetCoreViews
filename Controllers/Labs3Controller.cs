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
    public class Labs3Controller : Controller
    {
        private readonly ProbkiDb _context;

        public Labs3Controller(ProbkiDb context)
        {
            _context = context;
        }

        // GET: Labs3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labs.ToListAsync());
        }

        public async Task<IActionResult> Probka(int id)
        {
            var studenciGrupy = _context.Probka.Include(s => s.Lab).Where(s => s.FkLab == id);
            return PartialView(await studenciGrupy.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _context.Lab.Include(g => g.Probki).ToListAsync());
        }

    }
}
