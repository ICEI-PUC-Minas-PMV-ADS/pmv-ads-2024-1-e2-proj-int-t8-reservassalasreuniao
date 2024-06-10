using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace reserva_sala_reuniao.Models.ViewModel
{
    public class DadosRelatorio
    {
        [DisplayName("Id")]
        public long Id { get; set; }

        [DisplayName("Total Horas")]
        public string TotalHoras { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
