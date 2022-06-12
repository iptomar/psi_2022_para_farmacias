using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parafarmácia.Models
{
    public class ProdutoCart
    {
        public ProdutoCart() {

            ProdutosList = new HashSet<Produto>();
            CartsList = new HashSet<ShoppingCarts>();
        }

        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Quantidade total
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Quantidade")]
        public double Quantity { get; set; }


        /// <summary>
        /// Preço total
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Preço")]
        public double Price { get; set; }

        /// <summary>
        /// FK Produto
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Produto")]
        [ForeignKey(nameof(Produto))]
        public double ProdutoFK { get; set; }
        public Produto Produto { get; set; }

        /// <summary>
        /// FK Shopping Carts
        /// </summary>

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "ShoppingCart")]
        [ForeignKey(nameof(ShoppingCart))]
        public double ShoppingCartFK { get; set; }
        public ShoppingCarts ShoppingCart { get; set; }

        public ICollection<Produto> ProdutosList { get; set; }
        public ICollection<ShoppingCarts> CartsList { get; set; }
        
    }
}