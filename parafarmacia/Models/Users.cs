using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parafarmacia.Models
{
    public class Users
    {
        public Users()
        {
            OrdersList = new HashSet<Orders>();
            CartsList = new HashSet<Carts>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é de preenchimento obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(80, ErrorMessage = "O nome não pode ter mais de {1} carateres.")]
        public string Name { get; set; }

        public ICollection<Orders> OrdersList { get; set; }
        public ICollection<Carts> CartsList { get; set; }
    }
}
