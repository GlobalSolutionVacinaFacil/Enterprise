using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Vacina.Facil.Models
{
    [Table("T_VacinaFacil_Cliente")]
    public class Cliente
    {
        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo deve ter 100 caracteres.")]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo deve ter 100 caracteres.")]
        public string? Email { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "O campo deve ter 12 caracteres.")]
        public string? Telefone { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "O campo deve ter 14 caracteres.")]
        public string? Cpf { get; set; }

        [Required]
        [DataType(DataType.Date), Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("Situacao"), Required, Display(Name = "Situação")]
        public SituacaoCliente SituacaoCliente { get; set; }

        public IList<Dependente> Dependentes { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

    }

    public enum SituacaoCliente
    {
        ATIVO, INATIVO
    }
}
