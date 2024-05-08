using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_sala_reuniao.Models
{
    [Table("Relatorio")]
    public class Relatorio
    {
        [Key]
        public long Id { get; set; }
        
        [ForeignKey("TipoRelatorio")]
        public long TipoRelatorioId { get; set; }
        
        public virtual RelatorioTipo RelatorioTipo { get; set; }
        
        public string Arquivo { get; set; }
    }

}