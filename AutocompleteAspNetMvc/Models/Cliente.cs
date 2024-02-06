using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutocompleteAspNetMvc.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O nome do cliente deve ter até 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "O CEP deve ter 9 caracteres, contando com o traço")]
        public string CEP { get; set; }

        [Required]
        [RegularExpression("(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)", ErrorMessage = "Informe um estado válido.")]
        public string UF { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O bairro deve ter até 50 caracteres")]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O endereço deve ter até 100 caracteres")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [MaxLength(20, ErrorMessage = "O complemento do endereço deve ter até 20 caracteres")]
        public string Complemento { get; set; }

        [ForeignKey("Cidade")]
        public int IdCidade { get; set; }

        public virtual Cidade Cidade{ get; set; }
    }
}