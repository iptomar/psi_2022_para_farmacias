using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parafarmacia.Models
{
    public class Carts
    {
        public Carts()
        {
            ProductCartList = new HashSet<ProductCart>();
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Preço total
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Preço Total")]
        public double Total { get; set; }

        /// <summary>
        /// FK users
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [ForeignKey(nameof(User))]
        public int UserFK { get; set; }
        public Users User { get; set; }

        public ICollection<ProductCart> ProductCartList { get; set; }

    }
}