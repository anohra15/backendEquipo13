using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Implementations
{
    public class AseguradoDAO : IAseguradoDAO
    {
        public readonly IRCVDbContext _context;
        public AseguradoEntity asegurado = new AseguradoEntity();
        public string mensajeError = "Ocurrio un error inesperado ";

        public AseguradoDAO(IRCVDbContext context)
        {
            _context = context;
        }

        public bool valiacion(int ci) //verifico si existe un asegurado por cédula
        {
            var asegurados = _context.asegurado
                .Where(b => b.ci == ci)
                .Select(p => new PAseguradoDTO
                {
                    ci = p.ci,
                    full_name = p.primer_n + " " + p.primer_a
                });
            if(asegurados.ToList().Count == 0){
                return false;
            }
            return true;
        }
        
        public string createInsured(AseguradoDTO insured)//inserta asegurado
        {
            int i;
            bool validacion = valiacion(insured.ci);
            if (validacion == false) // si no existe
            {
                try{
                    var asegurado = new AseguradoEntity{
                        ci = insured.ci, 
                        primer_n = insured.primer_n, 
                        segundo_n = insured.segundo_n,
                        primer_a = insured.primer_a,
                        segundo_a = insured.segundo_a,
                        sexo = insured.sexo
                    };
                    var data =_context.asegurado.Add(asegurado);
                    i = _context.DbContext.SaveChanges();
                    return "Éxitoso";
                }
                catch(Exception ex){
                    throw new RCVExceptions("No se puede crear, detalles: ", ex);
                
                }
            }
            else
            {
                return "Asegurado ya existe";
            }
        }
        
        public List<PAseguradoDTO> getInsured() //trae todos los asegurados (BIEN)
        {
            try
            {
                var asegurados = _context.asegurado
                    //.Include(insured => insured.ci)
                    .Select( p => new PAseguradoDTO{
                        ci = p.ci,
                        full_name = p.primer_n + " " + p.primer_a
                    }).ToList();
                if(asegurados.ToList().Count == 0){
                    throw new Exception("No hay asegurados");
                }
                return asegurados.ToList();
            }
            catch(Exception ex){
                throw new RCVExceptions("No se ha podido presentar la lista de asegurados", ex.Message, ex);
            }
        }
        
        public PAseguradoDTO getInsured(int ci) //me trae un asegurado (BIEN)
        {
            try
            {
                var asegurados = _context.asegurado
                    .Where(b => b.ci == ci)
                    .Select(p => new PAseguradoDTO
                    {
                        ci = p.ci,
                        full_name = p.primer_n + " " + p.primer_a
                    });
                if(asegurados == null){
                    throw new Exception("No existe ese asegurado");
                }
                return asegurados.ToList()[0];
            }
            catch(Exception ex)
            {
                throw new RCVExceptions("No se ha podido presentar la lista de asegurados", ex.Message, ex);
            }
        }
    }
}