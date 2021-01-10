using Load_on_demand.Data;
using Load_on_demand.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Load_on_demand.Controllers
{

    [Authorize]
    public class NaseljaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NaseljaController(
            ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Naselja()
        {
            var popis = _context.Naselja
                .Select(result => new NaseljeModel
                {
                    Država = result.ŠifrarnikDržava.DržavaNaziv,
                    NazivNaselja = result.NazivNaselja,
                    PoštanskiBroj = result.PoštanskiBroj,
                    IDnaselja = result.NaseljeID
                })
                .OrderBy(x => x.Država).ToList();

            return View(popis);
        }

        [HttpPost]
        public IActionResult Naselja(NaseljeModel model)
        {
            var kodDržave = _context.ŠifrarnikDržava.SingleOrDefault(x => x.DržavaNaziv == model.Država);
            // EDIT člana
            if (_context.Naselja.SingleOrDefault(x => x.NaseljeID == model.IDnaselja) != null)
            {
                var edit = _context.Naselja
                    .Where(x => x.NaseljeID == model.IDnaselja)
                    .SingleOrDefault();
                edit.PoštanskiBroj = model.PoštanskiBroj;
                edit.NazivNaselja = model.NazivNaselja;
                edit.DržavaID = kodDržave.DržavaID;
                _context.Naselja.Update(edit);
                _context.SaveChanges();
            }
            // NOVI član
            else
            {
                var naselje = new Naselje
                {
                    NazivNaselja = model.NazivNaselja,
                    DržavaID = kodDržave.DržavaID,
                    PoštanskiBroj = model.PoštanskiBroj
                };
                _context.Add(naselje);
                _context.SaveChanges();
            }
            return Naselja();
        }

        public IActionResult ObrišiNaselje(int? IDnaselja)
        {
            if (IDnaselja == null)
            {
                return NotFound();
            }
            var naselje = _context.Naselja.SingleOrDefault(x => x.NaseljeID == IDnaselja);
            if (naselje == null)
            {
                return NotFound();
            }
            _context.Naselja.Remove(naselje);
            _context.SaveChanges();
            return RedirectToAction(nameof(Naselja));
        }

        public ActionResult GetData(NaseljeModel drzava)
        {
            var popis = _context.ŠifrarnikDržava.Where(x => x.DržavaNaziv.Contains(drzava.Država))
                .Select(result => new NaseljeModel
                {
                    Država = result.DržavaNaziv,
                    KodDržave = result.DržavaID
                })
                .OrderBy(x => x.Država).ToList();
            return Json(popis);
        }


    }
}
