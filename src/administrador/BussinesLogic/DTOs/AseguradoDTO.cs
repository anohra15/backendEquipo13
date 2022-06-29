using System;
using System.Collections.Generic;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.DTOs
{
    public class AseguradoDTO
    {
       // public Guid Id { get; set; }
        public int ci { get; set; }
        public string primer_n { get; set; }
        public string segundo_n { get; set; }
        public string primer_a { get; set; }
        public string segundo_a { get; set; }
        public char sexo { get; set; }
        
        //public HashSet<PolizaEntity> asegurado { get; set; }
    }
    
    public class PAseguradoDTO
    {
        // public Guid Id { get; set; }
        public int ci { get; set; }
        public string full_name { get; set; }
        //public HashSet<PolizaEntity> asegurado { get; set; }
    }
}