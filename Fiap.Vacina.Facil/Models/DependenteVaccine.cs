using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Vacina.Facil.Models
{
    public class DependenteVaccine
    {
        public int DependenteId { get; set; }
        public Dependente Dependente { get; set; }

        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set;}

    }
}
