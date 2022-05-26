using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projetoPSI.Models
{
    public class MedicamentoReceita
    {


        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /*[Required]
        public int Quant { get; set; }*/

        /// <summary>
        ///Ligação a tabela Receita
        /// </summary>
        [Required]
        [ForeignKey(nameof(Receita))]
        public int ReceitaFk { get; set; }
        public Receita Receita { get; set; }


        /// <summary>
        ///Ligação a tabela Medicamento
        /// </summary>
        [Required]
        [ForeignKey(nameof(Medicamento))]
        public int MedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}
