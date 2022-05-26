using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoPSI.Models
{
    public class Receita
    {
        /// <summary>
        /// Id da receita médica
        /// </summary>
        [Key]
        public int ReceitaId { get; set; }

        /// <summary>
        /// Preço total da receita médica
        /// </summary>
        [Display(Name = "Preço do(s) medicamento(s) total")]
        public string Preco { get; set; }


        ///<sumary>
        /// Data de quando a receita médica foi receitada
        /// </sumary
        public DateTime ReceitaData { get; set; }



        /// <summary>
        /// FK do utente da receita médica
        /// </summary>
        [ForeignKey(nameof(Utente))]
        public int UtenteIDFK { get; set; }
        public Utente UtenteID { get; set; }

        //lista de medicamentos receitas

        public virtual ICollection<MedicamentoReceita> MedicamentoReceita { get; set; }

        public Receita()
        {
            MedicamentoReceita = new HashSet<MedicamentoReceita>();
        }
    }
}
