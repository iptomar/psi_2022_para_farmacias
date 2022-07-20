using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO_PSI_2122_21296.Models {
    
    /// <summary>
    /// Representa os dados dos medicamentos.
    /// </summary>
    public class Medicamento {

        /// <summary>
        /// Chave primária para a tabela dos medicamentos.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do medicamento.
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique o nome do medicamento.")]
        public string Nome { get; set; }

        /// <summary>
        /// Preço do medicamento.
        /// </summary>
        [Display(Name = "Preço")]
        [RegularExpression("[0-9]{1,8}[,.]?[0-9]{0,2}", ErrorMessage = "Indique, por favor, o valor do medicamento...")]
        [Required(ErrorMessage = "Por favor, indique o valor do medicamento.")]
        public string Preco { get; set; }

        /// <summary>
        /// Data de validade do medicamento.
        /// </summary>
        [Display(Name = "Data de validade")]
        [Required(ErrorMessage = "Por favor, indique a data de validade do medicamento.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }

    }

}
