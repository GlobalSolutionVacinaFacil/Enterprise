using Fiap.Vacina.Facil.Models;
using Fiap.Vacina.Facil.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Vacina.Facil.Controllers
{
    public class VaccineController : Controller
    {

        private VacinaFacilContext _context;

        public VaccineController(VacinaFacilContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filtro = "")
        {
            var vacinas = _context.Vaccines
                .Where(p => p.Nome.Contains(filtro) || string.IsNullOrEmpty(filtro))
                .Include(p => p.Fabricantes)
                .ToList();
            return View(vacinas);
        }

        [HttpGet]
        public IActionResult Cadastrar() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Cadastrar(Vaccine vac) 
        {
            _context.Vaccines.Add(vac);
            _context.SaveChanges();
            TempData["msg"] = "Vacina cadastrada";
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Dashboard()
        {
            try
            {
                var unique = _context.Vaccines.Where(c => c.DoseVacina == DoseVacina.UNIQUE).Count();
                var pair = _context.Vaccines.Where(c => c.DoseVacina == DoseVacina.PAIR).Count();
                var triple = _context.Vaccines.Where(c => c.DoseVacina == DoseVacina.TRIPLE).Count();

                ViewBag.VaccinesUnique = unique;
                ViewBag.VaccinesPair = pair;
                ViewBag.VaccinesTriple = triple;
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Erro na Dashboard!";
                return View();
            }

            return View();

        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var vac = _context.Vaccines.Find(id);
            _context.Vaccines.Remove(vac);
            _context.SaveChanges();
            TempData["msg"] = "Vacina excluída!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            //var paciente = _context.Vaccines
            //    .Include(p => p.Endereco).First(p => p.vac == id);
            return View();
        }


        public IActionResult Editar(Vaccine vaccine)
        {
            _context.Vaccines.Update(vaccine);
            _context.SaveChanges();
            TempData["msg"] = "Vacina editada!";
            return RedirectToAction("Index");
        }



    }
}
