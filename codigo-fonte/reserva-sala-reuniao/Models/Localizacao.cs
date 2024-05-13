using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Localizacao")]
    public class Localizacao
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public string Nome { get; set; }
        
       
        public string Descricao { get; set; }

        // Relacao de um para muitos com Sala
        public virtual ICollection<Sala> Salas { get; set; }

    }

}