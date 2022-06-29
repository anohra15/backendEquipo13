using System;
using System.ComponentModel.DataAnnotations;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;

namespace backendRCVUcab.Persistence.Entities
{
    public class PiezasEntity:BaseEntity
    {
        [Required]
        public string descripcion_pieza{ get; set; }
        [Required]
        public Guid id_marcca_pieza{ get; set; }
        [Required]
        public CheckEstadoPieza estado{ get; set; }
        public double? precio{ get; set; }
        public AnalisisEntity analisis{ get; set; }
    }
}