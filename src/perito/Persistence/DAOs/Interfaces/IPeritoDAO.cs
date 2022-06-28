using perito.BussinesLogic.DTOs;

namespace perito.Persistence.DAOs.Interfaces
{
    public interface IPeritoDAO
    {
        public int CreatePerito(PeritoDTO perito);

        public int ActualizarPerito(PeritoDTO perito, string email);
    }
}