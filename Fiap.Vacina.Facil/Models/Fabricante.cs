using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Vacina.Facil.Models
{
    [Table("T_VacinaFacil_Fabricante")]
    public class Fabricante
    {
        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FabricanteId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo deve ter no 100 caracteres.")]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "O campo deve ter no 14 caracteres.")]
        [RegularExpression(@"^\d{14}$")]
        public string? Cnpj { get; set; }

    }
}
