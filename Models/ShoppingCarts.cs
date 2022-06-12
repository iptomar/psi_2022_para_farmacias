using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parafarmácia.Models
{
    public class ShoppingCarts
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Preço total
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Preço Total")]
        public double Total { get; set; }
    }
}