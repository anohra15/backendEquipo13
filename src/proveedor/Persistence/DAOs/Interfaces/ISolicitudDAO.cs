using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ISolicitudDAO
    {
        public int CreateSolicitud(SolicitudDTO solicitud);
    }
}