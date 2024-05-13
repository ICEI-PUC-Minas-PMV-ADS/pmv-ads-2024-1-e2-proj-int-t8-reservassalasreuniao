using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public long Id { get; set; }
        
        
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data")]
        public DateTime Data { get; set; }

        [Display(Name = "Horario da reserva")]
        [Required(ErrorMessage = "Obrigatório informar o horario da reserva")]
        public int HorasReservadas { get; set; }

        [ForeignKey("Sala")]
        [Display(Name = "Sala")]
        public long SalaId { get; set; }
        
        public virtual Sala Sala { get; set; }

        [ForeignKey("Usuario")]
        [Display(Name = "Usuario")]
        public long UsuarioId { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }

}