using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public long Id { get; set; }
       
        [ForeignKey("Usuario")]
        public long UsuarioId { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}