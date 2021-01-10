using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Load_on_demand.Models
{
    public class NaseljeModel
    {
        public int IDnaselja { get; set; }
        [Display(Name = "Poštanski broj")]
        public int PoštanskiBroj { get; set; }
        [Display(Name = "Naziv naselja")]
        public string NazivNaselja { get; set; }
        public string Država { get; set; }
        public int KodDržave { get; set; }
        public int Broj { get; set; }
    }
}
