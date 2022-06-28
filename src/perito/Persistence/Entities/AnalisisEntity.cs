using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace perito.Persistence.Entities
{
    [Table("Analisis")]
    public class AnalisisEntity: BaseEntity
    {
        [NotMapped] public Guid id_incidente { get; set; }
        [NotMapped] public Guid id_carro { get; set; }
        [NotMapped] public Guid id_perito { get; set; }
        [NotMapped] public Guid id_usuario_taller { get; set; }
        [NotMapped] public ICollection<Guid> id_piezas { get; set; } //Atributo que indica la lista de piezas danadas
    }
}