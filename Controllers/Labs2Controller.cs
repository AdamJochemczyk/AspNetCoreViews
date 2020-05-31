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
    public class Labs2Controller : Controller
    {
        private readonly ProbkiDb _context;

        public Labs2Controller(ProbkiDb context)
        {
            _context = context;
        }

        // GET: Labs2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labs.ToListAsync());
        }

        public async Task<IActionResult> Probka(int id)
        {
            var probkiLab = _context.Probka.Include(s => s.Lab).Where(s => s.FkLab == id); //include pozwoli przy studencie wyświetlić nazwę jego grupy, pochodzącą z innej klasy (tabeli)
            return View(await probkiLab.ToListAsync());
        }

    }
}
