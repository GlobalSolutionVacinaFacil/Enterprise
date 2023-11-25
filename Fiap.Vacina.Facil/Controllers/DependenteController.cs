using Fiap.Vacina.Facil.Models;
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

        public IActionResult Index(int clienteId, string pesquisa = "")
        {
            List<Dependente> dependentes = _context.Dependentes
                                                    .Where(d => d.ClienteId == clienteId)
                                                    .Where(d => d.Nome.Contains(pesquisa) || string.IsNullOrEmpty(pesquisa))
                                                    .ToList();
            ViewBag.ClienteId = clienteId;

            return View(dependentes);
        }

        [HttpGet]
        public IActionResult Cadastrar(int clienteId)
        {
            return View(clienteId);
        }

        [HttpPost]
        public IActionResult Cadastrar(Dependente dependente)
        {
            _context.Add(dependente);
            _context.SaveChanges();
            TempData["msg"] = "Dependente registrado";
            return RedirectToAction("Cadastrar", new { dependente.ClienteId });
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var dependente = _context.Dependentes.Where(c => c.DependenteId == id).FirstOrDefault();

            try
            {

                if (dependente != null)
                {
                    _context.Remove(dependente);
                    _context.SaveChanges();
                    TempData["msg"] = "Dependente deletado com sucesso!";
                }
                else
                {
                    TempData["msg"] = "Dependente não encontrado!";
                }
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao deletar o dependente!";
            }

            return RedirectToAction("Index", new { clienteId = dependente?.ClienteId ?? 0});

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var dependente = _context.Dependentes.Where(c => c.DependenteId == id).FirstOrDefault();

                if (dependente == null)
                {
                    TempData["msg"] = "Dependente não encontrado!";
                    return RedirectToAction("Index");
                }

                return View(dependente);
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao editar Dependente!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(Dependente dependente)
        {
            try
            {
                _context.Dependentes.Update(dependente);
                _context.SaveChanges();
                TempData["msg"] = "Dependente editado";
                return RedirectToAction("Index", new {dependente.ClienteId});
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao editar Dependente!";
                return View(dependente);
            }
        }

    }

}
