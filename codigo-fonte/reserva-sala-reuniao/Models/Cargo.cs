using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Key]
        public long Id { get; set; }
        
        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Obrigatório informar o nome")]
        public string Nome { get; set; }
          
        public string Descricao { get; set; }

        //Relacao de um para muitos com Usuario
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }

}