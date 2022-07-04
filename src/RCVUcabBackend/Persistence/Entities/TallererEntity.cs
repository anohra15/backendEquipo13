using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;

namespace backendRCVUcab.Persistence.Entities
{
    [Table("Taller")]
    public class TallererEntity:BaseEntity
    {
        [MaxLength(300)]
        [Required]
        public string nombre_taller { get; set; }
        [MaxLength(300)]
        [Required]
        public string direccion { get; set; }
        [Required]
        public int cumplimiento { get; set; }
        [MaxLength(20)]
        [Required]
        public string RIF { get; set; }
        [Required]
        public CheckEstadoTaller estado { get; set; }
        public ICollection<MarcaCarroEntity> marcas { get; set; }
        [NotMapped]
        public ICollection<Guid> UsuariosTaller { get; set; }
    }
}