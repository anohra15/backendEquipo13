using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities
{
    public class PolizaEntity:BaseEntity
    {
        [Required]
        public string tipo { get; set; }
        [Column(TypeName = "DATE")]
        [Required]
        public DateTime vencimiento { get; set; } 
        public bool desactivada { get; set; }
        public ICollection<AseguradoEntity> asegurado { get; set; }
        public ICollection<IncidentesEntity> incidentes { get; set; }
    }
}