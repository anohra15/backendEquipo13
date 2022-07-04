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
using Microsoft.VisualBasic;

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
        
        /*EVAUACIÓN INDIVIDUAL EN CLASE TRAER POLIZAS CON FECHA DE VENCIMIENTO*/
        public List<PolizaSimpleDTO> getPolicy(DateTime fecha) //trae todas las polizas
        {
            try
            {
                var poliza = _context.poliza
                    .Where(p => p.vencimiento == fecha)
                    .Select( p => new PolizaSimpleDTO(){
                        tipo = p.tipo,
                        vencimiento = p.vencimiento,
                        asegurado = p.asegurado
                    }).ToList();
                if(poliza.ToList().Count == 0){
                    throw new Exception("No hay polizas, con esa fecha");
                }
                return poliza.ToList();
            }
            catch(Exception ex){
                throw new RCVExceptions("No se ha podido presentar las polizas", ex.Message, ex);
            }
        }

        public string NotImplementedException { get; set; }
    } 
}
