using Fiap.Vacina.Facil.Models;
using Fiap.Vacina.Facil.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Vacina.Facil.Controllers
{
    public class AvisoController : Controller
    {

        private VacinaFacilContext _context;

        public AvisoController(VacinaFacilContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Avisos.ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

 
    }
}
