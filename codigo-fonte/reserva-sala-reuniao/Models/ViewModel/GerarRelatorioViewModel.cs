using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reserva_sala_reuniao.Models.ViewModel
{
    public class GerarRelatorioViewModel
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Obrigatório informar a data")]
        [DisplayName("Inicio")]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Obrigatório informar a data")]
        [DisplayName("Fim")]
        public DateTime DataFinal { get; set; }

        [DisplayName("Tipo Relatório")]
        public int IdTipo { get; set; }
    }
}
