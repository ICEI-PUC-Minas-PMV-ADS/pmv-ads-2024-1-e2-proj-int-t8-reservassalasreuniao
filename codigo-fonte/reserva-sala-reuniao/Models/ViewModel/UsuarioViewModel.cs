using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace reserva_sala_reuniao.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Nome do usuario")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Setor")]
        public string NomeSetor { get; set; }

        [Display(Name = "Cargo")]
        public string NomeCargo { get; set; }

        [Display(Name = "Perfil")]
        public virtual Perfil Perfil { get; set; }

    }
}