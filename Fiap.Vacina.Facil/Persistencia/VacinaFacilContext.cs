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

        public DbSet<ClienteAviso> ClienteAvisos { get; set; }

        public VacinaFacilContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a PK da tabela associativa
            modelBuilder.Entity<ClienteAviso>()
                .HasKey(p => new { p.ClienteId, p.AvisoId });


            // Configurar a relação da tabela associativa com o Cliente
            modelBuilder.Entity<ClienteAviso>()
                .HasOne(p => p.Cliente)
                .WithMany(p => p.ClienteAvisos)
                .HasForeignKey(p => p.ClienteId);

            // Configurar a relação da tabela associativa com o Aviso
            modelBuilder.Entity<ClienteAviso>()
                .HasOne(p => p.Aviso)
                .WithMany(p => p.ClienteAvisos)
                .HasForeignKey(p => p.AvisoId);


            base.OnModelCreating(modelBuilder);
        }

    }
}