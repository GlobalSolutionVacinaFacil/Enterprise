using Fiap.Vacina.Facil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Vacina.Facil.Persistencia
{
    public class VacinaFacilContext : DbContext
    {

        public DbSet<Aviso> Avisos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Dependente> Dependentes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        public VacinaFacilContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}