using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Nome do usuario")]
        [Required(ErrorMessage = "Obrigatório informar o nome do usuario")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Obrigatório informar o email")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Obrigatório informar a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [ForeignKey("Setor")]
        public long SetorId { get; set; }
        public virtual Setor Setor { get; set; }

        [ForeignKey("Cargo")]
        public long CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public virtual Perfil Perfil { get; set; }

        // Relação com outras tabelas
        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }

    public enum Perfil
    {
        User,
        Admin
    }
}