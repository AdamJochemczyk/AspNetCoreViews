using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zaj9.Models;
using zaj9.ViewModels;

namespace zaj9.Controllers
{
    public class Labs1Controller : Controller
    {
        private readonly ProbkiDb _context;

        public Labs1Controller(ProbkiDb context)
        {
            _context = context;
        }

        // GET: Labs1
        public async Task<IActionResult> Index(int? id)
        {
            LabProbki lp = new LabProbki();
            lp.Lab = await _context.Lab.ToListAsync();
            lp.LiczbaZestawowBadan = await _context.Probka.CountAsync();

            if(id!=null)
            {
                lp.IdZaznaczonegoLab = id;
                lp.Probki = await _context.Probka
                    .Where(s => s.FkLab == id)
                    .OrderBy(s => s.Nazwa_Probki).ThenBy(s => s.zbadane)
                    .ToListAsync();
                lp.LiczbaZestawowBadanwLab = await _context.Probka
                    .Where(s => s.FkLab == id)
                    .CountAsync();
                if (lp.LiczbaZestawowBadanwLab != 0)
                {
                    lp.SredniaWagaProbek = await _context.Probka
                        .Where(s => s.FkLab == id)
                        .AverageAsync(s => s.Waga_Probek);
                    lp.NajciezszyZestawProbek = await _context.Probka
                        .Where(s => s.FkLab == id)
                        .MaxAsync(s => s.Waga_Probek);
                    lp.NajlzejszyZestawProbek = await _context.Probka
                        .Where(s => s.FkLab == id)
                        .MinAsync(s => s.Waga_Probek);
                }
            }
            return View(lp);
        }

    }
}
