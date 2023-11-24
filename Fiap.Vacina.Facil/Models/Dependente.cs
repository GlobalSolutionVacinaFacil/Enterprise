using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Vacina.Facil.Models
{
    [Table("T_VacinaFacil_Dependente")]
    public class Dependente
    {

        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DependenteId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo deve ter no 100 caracteres.")]
        public string? Nome { get; set; }

        [DataType(DataType.Date), Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }


    }
}
