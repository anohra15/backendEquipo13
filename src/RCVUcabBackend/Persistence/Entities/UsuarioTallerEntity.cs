using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{
    [NotMapped]
    public class UsuarioTallerEntity:BaseEntity
    {
        [MaxLength(200)]
        [Required]
        public string primer_nombre { get; set; }
        [MaxLength(250)]
        public string? segundo_nombre { get; set; }
        [MaxLength(200)]
        [Required]
        public string primer_apellido { get; set; }
        [MaxLength(250)]
        public string? segundo_apellido { get; set; }
        [MaxLength(300)]
        [Required]
        public string direccion { get; set; }
        [MaxLength(200)]
        [Required]
        public string cargo { get; set; }
        [MaxLength(200)]
        [Required]//Activo o desactivo
        public string estado { get; set; }
        [MaxLength(500)]
        public string? email { get; set; }
        [MaxLength(20)]
        [Required]
        public string contraseña { get; set; }
        [Required]
        public Guid idTaller;
        
        //Atributo que representa los telefonos del usuario de ese taller
        [NotMapped]
        public ICollection<Guid> Telefonos { get; set; }
        
        //Atributo que representa los analisis de incidentes asignados al taller de este usuario
        [NotMapped]
        public ICollection<Guid> analisis { get; set; }
        
        //Atributo que representa las cotizaciones que realizo este usuario
        [NotMapped]
        public ICollection<Guid> cotizaciones_taller { get; set; }
    }
}