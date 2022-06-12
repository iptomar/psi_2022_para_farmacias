using System;
using System.ComponentModel.DataAnnotations;

namespace Parafarmácia.Models
{
    public class CategoriasProdutos
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [StringLength(40, ErrorMessage = "O nome não pode ter mais de {1} carateres.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

    }
}
