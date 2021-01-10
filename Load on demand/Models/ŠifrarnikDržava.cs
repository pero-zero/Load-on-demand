using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Load_on_demand.Models
{
    public class ŠifrarnikDržava
    {
        [Key]
        public int DržavaID { get; set; }
        [Display(Name = "Naziv Države")]
        public string DržavaNaziv { get; set; }
    }
}
