using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Vacina.Facil.Models
{
    [Table("T_VacinaFacil_End")]
    public class Endereco
    {
        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnderecoId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo deve ter 100 caracteres.")]
        public string? Logradouro { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "O campo deve ter 5 caracteres.")]
        public string? Numero { get; set; }

        [Required]
        [MaxLength(8)]
        public string? Cep { get; set; }


        [Column("Situacao"), Required, Display(Name = "Situação do Endereço")]
        public SituacaoEndereco SituacaoEndereco { get; set; }

    }

    public enum SituacaoEndereco
    {
        ATIVO,
        INATIVO
    }

}
