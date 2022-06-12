using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parafarmácia.Models
{
    public class Produto 
    {
        public Produto()
        { }
            
            /// <summary>
            /// Referencia o produto
            /// </summary>
            [Key]
          
            public int Id { get; set; }

            /// <summary>
            /// Nome do produto
            /// </summary>
            
            [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
            [StringLength(40, ErrorMessage = "O nome não pode ter mais de {1} carateres.")]
            [Display(Name = "Nome")]
            public string Name { get; set; }

        /// <summary>
        /// Descricao do produto
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
            [Display(Name = "Descrição")]
            public string Description { get; set; }

        /// <summary>
        /// categorias do produto
        /// </summary>
            [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
            [Display(Name = "Categorias")]
            public string Category { get; set; }

            /// <summary>
            /// Imagem do produto
            /// </summary>
            [Display(Name = "Imagem")]
            public string Image { get; set; }

            /// <summary>
            /// Preço do produto
            /// </summary>
            [Display(Name = "Preço")]
            public double Price { get; set; }

            


        public ICollection<Orders> OrdersList { get; set; }
        public ICollection<ShoppingCarts> ShoppingCarts { get; set; }
        
      
    }

}
