using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface IProveedorDAO
    {
        public int CreateProveedor(ProveedorDTO proveedor);
    }
}