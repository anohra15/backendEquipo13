using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Reflection.Metadata;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;

namespace backendRCVUcab.Persistence.Entities
{
    [Table("Orden_compra")]
    public class OrdenCompraEntity:BaseEntity
    {
        [Required]
        public int limite_dias_pago { get; set; }
        [Column(TypeName = "DATE")]
        [Required]
        public DateTime fecha_vencimiento { get; set; }
        [Required]
        public double total_pagar { get; set; }
        [MaxLength(500)]
        [Required]
        public string descripcion { get; set; }
        public string? factura { get; set; }
        [Required]
        public CheckEstadoOrdenDeCompra estado { get; set; }
        [ForeignKey("CotizacionTallerEntity")]
        public Guid idCotizacionTaller { get; set; }
        public CotizacionTallerEntity cotizacion;
    }
}