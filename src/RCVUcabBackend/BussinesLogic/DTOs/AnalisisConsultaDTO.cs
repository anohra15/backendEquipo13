using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.DTOs
{
    public class AnalisisConsultaDTO
    {
        public string titulo_analisis{get; set;}
        public string estado { get; set; }
    }
}