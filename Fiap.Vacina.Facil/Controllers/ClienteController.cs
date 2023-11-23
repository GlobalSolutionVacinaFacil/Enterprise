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
                .Where(p => p.SituacaoCliente == SituacaoCliente.ATIVO)
                .Include(p => p.Endereco)
                .ToList();
            return View(clientes);
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            try
            {
                var cliente = _context.Clientes.Where(c => c.ClienteId == id).FirstOrDefault();

                if (cliente != null)
                {
                    cliente.SituacaoCliente = SituacaoCliente.INATIVO;
                    _context.Update(cliente);
                    _context.SaveChanges();
                    TempData["msg"] = "Cliente deletado com sucesso!";
                }
                else
                {
                    TempData["msg"] = "Cliente não encontrado!";
                }
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao deletar o cliente!";
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var cliente = _context.Clientes.Where(c => c.ClienteId == id).FirstOrDefault();
                cliente.Endereco = _context.Enderecos.Where(e => e.EnderecoId == cliente.EnderecoId).FirstOrDefault();

                if(cliente == null)
                {
                    TempData["msg"] = "Cliente não encontrado!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao editar cliente!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                TempData["msg"] = "Cliente editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["msg"] = "Erro ao editar cliente!";
                return View(cliente);
            }
        }
    }
}
