using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;

namespace backendRCVUcab.Persistence.Entities
{
    public class AnalisisEntity:BaseEntity
    {
        
        [Required]
        public Guid id_usuario_taller { get; set; }
        public Guid? cotizacion_taller { get; set; }
        [Required]
        public string titulo_analisis{get; set;}
        [Required]
        public CheckEstadoAnalisisAccidente estado { get; set; }

        public ICollection<PiezasEntity> piezas { get; set; }
    }
}