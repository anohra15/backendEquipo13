using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities
{
    public class IncidentesEntity:BaseEntity
    { 
        [Required]
        public UsuariosEntity admin { get; set; }
        [Required]
        public PolizaEntity poliza { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime fecha { get; set; } //fecha en la que ocurrió
    }
}