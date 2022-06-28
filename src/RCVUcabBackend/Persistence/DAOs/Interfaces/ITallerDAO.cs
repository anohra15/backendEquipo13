using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ITallerDAO
    {
        public int CreateTaller(TallerDTO taller);
        
    }
}