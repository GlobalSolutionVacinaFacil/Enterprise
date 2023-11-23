using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Vacina.Facil.Models
{
    [Table("T_VacinaFacil_Vaccine")]
    public class Vaccine
    {
        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VaccineId { get; set; }

        [MaxLength(100, ErrorMessage = "O campo deve ter no 100 caracteres.")]
        [Required(ErrorMessage = "É necessário inserir um nome completo")]
        public string? Nome { get; set; }

        [DisplayName("Composição")]
        [Required]
        [MaxLength(100, ErrorMessage = "O campo deve ter no 100 caracteres.")]
        public string? Composicao { get; set; }

        [Required]
        [Range(1,100, ErrorMessage = "O valor deve estar entre 1 e 100.")]
        [DisplayName("Quantidade de meses para próxima dose da Vacina?")]
        public int Intervalo { get; set; }

        [Required(ErrorMessage = "Dose da Vacina é obrigatório")]
        public DoseVacina DoseVacina { get; set; }

        public IList<Fabricante> Fabricantes { get; set; }

        public Dependente Dependente { get; set; }

        public int DependenteId { get; set; }

        public IList<DependenteVaccine> DependenteVaccine { get; set; }


    }

    public enum DoseVacina
    {
        UNIQUE, PAIR, TRIPLE
    }

}
