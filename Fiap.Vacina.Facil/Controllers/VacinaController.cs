using Microsoft.AspNetCore.Mvc;

namespace Fiap.Vacina.Facil.Controllers
{
    public class VacinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
