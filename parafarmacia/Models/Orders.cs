using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace parafarmacia.Models
{
    public class Orders
    {
        public Orders()
        {
            OrderProductList = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public int NIF { get; set; }

        public ICollection<OrderProduct> OrderProductList { get; set; }
    }

}
