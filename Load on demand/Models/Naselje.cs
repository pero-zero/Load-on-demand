using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Load_on_demand.Models
{
    public class Naselje
    {
        [Key]
        public int NaseljeID { get; set; }
        [Display(Name = "Poštanski broj")]
        public int PoštanskiBroj { get; set; }
        [Display(Name = "Naziv naselja")]
        public string NazivNaselja { get; set; }
        [ForeignKey("ŠifrarnikDržava")]
        public int DržavaID { get; set; }
        public virtual ŠifrarnikDržava ŠifrarnikDržava { get; set; }
    }
}
