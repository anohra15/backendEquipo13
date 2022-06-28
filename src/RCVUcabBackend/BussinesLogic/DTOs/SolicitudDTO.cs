using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;


namespace RCVUcabBackend.BussinesLogic.DTOs
{
    public class SolicitudDTO
    {
        public string nombre { get; set; }
        
        public int estado { get; set; }

        public Guid idAnalisis;
        
        public Guid idProveedor;

        public Guid idUsuarioTaller;
    
        public List<PiezaDTO> piezas { get; set; }
    }
}