using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace projetoPSI.Models
{
    public class Utente
    {

        /// <summary>
        /// Id do utilizador utente
        /// </summary>
        [Key]
        public int UtenteId { get; set; }

        /// <summary>
        /// Nome do utilizador utente
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        public String Nome { get; set; }

        /// <summary>
        /// Data de nascimento do utilizador utente
        /// </summary>
        [Required(ErrorMessage = "Deve introduzir uma data válida")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }


           /// <summary>
        /// Nif do utilizador utente
        /// </summary>
        [RegularExpression("[^0-9]{9}", ErrorMessage = "Introduza apenas números")]
        [Required(ErrorMessage = "Deve introduzir o seu NIF")]
        [Display(Name = "Número de Identificação Fiscal")]
        public string NIF { get; set; }

        public string Sexo { get; set; }

        public string lig { get; set; }


        //lista de receitas
        public virtual ICollection<Receita> Receitas { get; set;}

        public Utente()
        {
            Receitas = new HashSet<Receita>();
        }



    }
}
