using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parafarmácia.Models
{
    public class Orders
    {
        public Orders()
        { }

        /// <summary>
        /// Referencia da order
        /// </summary>
        [Key]

        public int Id { get; set; }

        /// <summary>
        /// Descricao da order
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        /// <summary>
        /// Descricao da order
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "NIF")]
        public int NIF { get; set; }


    }

}
