using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zaj9.Models;

namespace zaj9.ViewModels
{
    public class LabProbki
    {
        public List<Lab> Lab { get; set; }
        public List<Probki> Probki { get; set; }
        public int? IdZaznaczonegoLab { get; set; }

        public double SredniaWagaProbek { get; set; }
        public double NajlzejszyZestawProbek { get; set; }
        public double NajciezszyZestawProbek { get; set; }
        public int LiczbaZestawowBadan { get; set; }
        public int? LiczbaZestawowBadanwLab { get; set; }
    }
}
