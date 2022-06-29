using System;
using System.Collections.Generic;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.DTOs
{
    public class PolizaDTO
    {
        public string tipo {get; set;}
        public DateTime vencimiento {get; set;}
        public bool desactivada {get; set;}
        public ICollection<AseguradoEntity> asegurado {get; set;}
        public ICollection<IncidentesEntity> incidentes {get; set;}
    }
    public class PolizaSimpleDTO
    {
        public string tipo {get; set;}
        public DateTime vencimiento {get; set;}
        public ICollection<AseguradoEntity> asegurado {get; set;}
    }
    public class PolizaIncidenteDTO
    {
        public ICollection<IncidentesEntity> Incidentes {get; set;}
    }
    public class desactivarIncidenteDTO
    {
        public bool desactivar {get; set;}
    }
}