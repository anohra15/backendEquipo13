using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{
    [Table("Pieza")]
    public class PiezaEntity: BaseEntity
    {
        [MaxLength(100)] [Required] public string nombre { get; set; }
    }
}