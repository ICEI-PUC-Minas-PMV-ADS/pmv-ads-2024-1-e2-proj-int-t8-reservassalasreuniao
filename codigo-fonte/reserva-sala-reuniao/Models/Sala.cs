using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Sala")]
    public class Sala
    {
        [Key]
        public long Id { get; set; }
        
        [ForeignKey("Localizacao")]
        [Display(Name = "Loacalizacao da sala")]
        [Required(ErrorMessage = "Obrigatório informar a localizacao da sala")]
        public long LocalizacaoId { get; set; }
        
        public virtual Localizacao Localizacao { get; set; }

        [Display(Name = "Lotacao maxima da sala")]
        [Required(ErrorMessage = "Obrigatório informar a lotacao maxima da sala")]
        public int LotacaoMaxima { get; set; }

        // Relacao de um para muitos com Reserva
        public virtual ICollection<Reserva> Reservas { get; set; }
    }

}