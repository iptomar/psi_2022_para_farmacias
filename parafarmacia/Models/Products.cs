using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parafarmacia.Models
{
    public class Products
    {
        public Products()
        {
            OrderProductList = new HashSet<OrderProduct>();
            ProductCartList = new HashSet<ProductCart>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome não pode ter mais de {1} carateres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public double Price { get; set; }

        /// <summary>
        /// FK Category
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [ForeignKey(nameof(Category))]
        public int CategoryFK { get; set; }
        public ProductCategories Category { get; set; }


        public ICollection<OrderProduct> OrderProductList { get; set; }
        public ICollection<ProductCart> ProductCartList { get; set; }
    }

}
