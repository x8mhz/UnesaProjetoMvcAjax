using System.ComponentModel.DataAnnotations;

namespace UnesaProjetoMvcAjax.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(150, ErrorMessage = "Nome deve conter entre 2 e 150 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Categoria")]
        [MaxLength(50, ErrorMessage = "Nome deve conter entre 2 e 150 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Categoria { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Valor { get; set; }
    }
}