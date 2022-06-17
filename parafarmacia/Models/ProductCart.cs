using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parafarmacia.Models
{
	public class ProductCart
	{
		public ProductCart()
		{
		}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public double Price { get; set; }

        /// <summary>
        /// FK Product
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [ForeignKey(nameof(Product))]
        public int ProductFK { get; set; }
        public Products Product { get; set; }

        /// <summary>
        /// FK Order
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [ForeignKey(nameof(Cart))]
        public int CartFK { get; set; }
        public Carts Cart { get; set; }
    }
}

