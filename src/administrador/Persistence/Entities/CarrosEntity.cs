using System;
using System.ComponentModel.DataAnnotations;

namespace administrador.Persistence.Entities
{
    public class CarrosEntity:BaseEntity
    {
        [Required]
        public PolizaEntity seguro { get; set; }
        [Required]
        public Guid marca { get; set; } // Antonio GUID PORQUE LO VAMOS A TRABAJAR CON RABBIT
        [Required]
        public string placa { get; set; }
        [Required]
        public string tipo { get; set; }
        [Required]
        public string color { get; set; }
    }
}