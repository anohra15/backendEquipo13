using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;

namespace backendRCVUcab.Persistence.Entities
{
    [Table("Cotizacion_taller")]
    public class CotizacionTallerEntity:BaseEntity
    {
        [Required]
        public int cantidad_piezas_reparar { get; set; }
        [Required]
        public double costo_reparacion { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? fecha_culminacion { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime? fecha_inicio { get; set; }
        [Required]
        public CheckEstadoCotizacionTaller estado { get; set; }
        [Required] public Guid usuario_taller { get; set; }
        public OrdenCompraEntity ordenCOmpra { get; set; }
        [NotMapped]
        public Guid idAnalisis;
        [NotMapped]
        public Guid idUsuarioTaller;
    }
}