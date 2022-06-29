using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administrador.Persistence.Entities;
namespace administrador.Persistence.DAOs.Implementations
{
    public class PolizaDAO : IPolizaDAO
    {
        public readonly IRCVDbContext _context;
        public PolizaEntity poliza = new PolizaEntity();
        public string mensajeError = "Ocurrio un error inesperado ";

        public PolizaDAO(IRCVDbContext context)
        {
            _context = context;
        }
        
        /*Crea una poliza con su tipo: Completa/Parcial*/
        public string createPoliza(PolizaSimpleDTO poliza, String tipo)//inserta asegurado
        {
            try{
                var policy = new PolizaEntity(){
                    tipo = tipo,
                    vencimiento = poliza.vencimiento,
                    asegurado = poliza.asegurado,
                };
                var data = _context.poliza.Add(policy);
                var response = _context.DbContext.SaveChanges();
                return "Poliza creada con éxito";
                }
                catch(Exception ex){
                    throw new RCVExceptions("No se puede crear la poliza", ex);
                }
        }
        
        /*Asigna incidentes a una poliza*/
        public string asignarIncidente(Guid guid, PolizaIncidenteDTO incidente)
        {
            var poliza = _context.poliza
                .Where(i => i.Id == guid)
                .Select(p => p.incidentes);
            foreach (var i in incidente.Incidentes)
            {
                
            }
            
            return NotImplementedException;
        }
        
        /*Desactivar poliza*/
        public async Task<bool> DeletePolicy(PolizaEntity poliza)
        {
            poliza.desactivada = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public string NotImplementedException { get; set; }
    } 
}
