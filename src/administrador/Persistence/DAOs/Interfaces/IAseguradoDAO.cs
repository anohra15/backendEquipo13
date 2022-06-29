using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IAseguradoDAO
    {
        public string createInsured(AseguradoDTO insured); // me crea un asegurado
        public List<PAseguradoDTO> getInsured(); // me trae todos los asegurados
        public PAseguradoDTO getInsured(int ci); // me trae un asegurado especifico
        public bool valiacion(int ci); // me valida un asegurado
    }
}