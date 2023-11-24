using Fiap.Vacina.Facil.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Vacina.Facil.Controllers
{
    public class DependenteController : Controller
    {


        private VacinaFacilContext _context;

        public DependenteController(VacinaFacilContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



    }

}
