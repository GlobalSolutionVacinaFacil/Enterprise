using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Fiap.Vacina.Facil.Persistencia;

namespace Fiap.Vacina.Facil.Models
{
    [Table("T_VacinaFacil_Aviso")]
    public class Aviso
    {

        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvisoId { get; set; }

        [Required]
        [Column("Dt_Aviso"), Display(Name = "Data do Aviso")]
        [DataType(DataType.Date)]
        public DateTime DataAviso { get; set; }

        [Required]
        [Column("Ds_Descrição")]
        [MaxLength(200, ErrorMessage = "O campo deve ter no 100 caracteres.")]
        public string? Descricao { get; set; }

       public IList<ClienteAviso> ClienteAvisos { get; set; }

       public Cliente Cliente { get; set; }

    }
}
