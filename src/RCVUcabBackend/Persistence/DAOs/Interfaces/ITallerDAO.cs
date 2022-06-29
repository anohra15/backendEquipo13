using System;
using System.Collections.Generic;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ITallerDAO
    {
        public int CreateTaller(TallerDTO taller);
        public int EliminarTaller(Guid taller);
        
        public int ActualizarTaller(TallerDTO taller,Guid id_taller);
        
        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignados(Guid id_taller);
        
        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignadosPorFiltro(Guid id_taller,CheckEstadoAnalisisAccidente filtro);
    }
}