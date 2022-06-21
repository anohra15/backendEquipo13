using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities
{
    public class PolizaEntity:BaseEntity
    {
        [Required]
        public AseguradoEntity asegurado { get; set; }
        [Required]
        public string tipo { get; set; } 
        [Column(TypeName = "DATE")]
        public DateTime vencimiento { get; set; } 
        public HashSet<IncidentesEntity> poliza { get; set; }
        public HashSet<PolizaEntity> seguro { get; set; }
    }
}