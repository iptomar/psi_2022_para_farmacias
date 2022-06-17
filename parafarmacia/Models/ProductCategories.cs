using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace parafarmacia.Models
{
    public class ProductCategories
    {

        public ProductCategories()
        {
            CategoryList = new HashSet<Products>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [StringLength(40, ErrorMessage = "O nome não pode ter mais de {1} carateres.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public ICollection<Products> CategoryList { get; set; }

    }
}
