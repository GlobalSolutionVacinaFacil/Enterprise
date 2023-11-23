using Fiap.Vacina.Facil.Models;
using Fiap.Vacina.Facil.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Vacina.Facil.Controllers
{
    public class ClienteController : Controller
    {
        private VacinaFacilContext _context;

        public ClienteController(VacinaFacilContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cli)
        {
            _context.Clientes.Add(cli);
            _context.SaveChanges();
            TempData["msg"] = "Cliente registrado";
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Index(string filtro = "")
        {
            var clientes = _context.Clientes
                .Where(p => p.Nome.Contains(filtro) || string.IsNullOrEmpty(filtro))
                .Include(p => p.Endereco)
                .ToList();
            return View(clientes);
        }

        /*
        public IActionResult Index(string filtro = "")
        {
            var lista = _context.Clientes
                .Where(p => p.Nome.Contains(filtro) || string.IsNullOrEmpty(filtro))
                .Include(p => p.Endereco)
                .ToList();
            return View(filtro);
        }*/

    }
}
