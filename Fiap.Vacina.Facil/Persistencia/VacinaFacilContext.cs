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

        public DbSet<Vaccine> Vaccine { get; set; }

        public DbSet<DependenteVaccine> DependenteVaccines { get; set; }

        public VacinaFacilContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a PK da tabela associativa
            modelBuilder.Entity<Aviso>()
                .HasKey(p => new { p.ClienteId, p.AvisoId });

            modelBuilder.Entity<DependenteVaccine>()
                .HasKey(p => new { p.DependenteId, p.VaccineId });

            // Configurar a relação da tabela associativa com o Cliente
            modelBuilder.Entity<Aviso>()
                .HasOne(p => p.Cliente)
                .WithMany(p => p.Avisos)
                .HasForeignKey(p => p.ClienteId);

            // Configurar a relação da tabela associativa - Dependente Vacinas
            modelBuilder.Entity<DependenteVaccine>()
                .HasOne(p => p.Dependente)
                .WithMany(p => p.DependenteVaccine)
                .HasForeignKey(p => p.VaccineId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete
            

            //Configurar a relação da tabela associativa - Dependente Vacinas
            modelBuilder.Entity<DependenteVaccine>()
                .HasOne(p => p.Vaccine)
                .WithMany(p => p.DependenteVaccine)
                .HasForeignKey(p => p.DependenteId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete
            


            base.OnModelCreating(modelBuilder);
        }

    }
}