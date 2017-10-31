using System.ComponentModel.DataAnnotations;

namespace UnesaProjetoMvcAjax.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(150, ErrorMessage = "Nome deve conter entre 2 e 150 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(15, ErrorMessage = "CPF inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Telefone")]
        [MaxLength(150, ErrorMessage = "Nome deve conter entre 2 e 150 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }
    }
}