using System;
using System.Collections.Generic;
using System.Linq;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
//using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.Persistence.DAOs.Implementations
{
    public class TallerDAO 
    {
        public readonly IRCVDbContext _context;
        public TallerDAO(IRCVDbContext context)
        {
            _context = context; }
       /* public TallererEntity Taller=new TallererEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado ";
        public ICollection<MarcaCarroEntity> listaMarcas= new List<MarcaCarroEntity>();
        
        

        public bool verificarMarca(IRCVDbContext context,MarcaDTO marcaValidar)
        {
            if (context.Marcas.Any(x => x.nombre_marca == marcaValidar.nombre_marca))
            {
                return true;   
            }
            return false;
        }

        public bool AsignarMarcaExistente(IRCVDbContext context,MarcaDTO marcaValidar)
        {
            if (verificarMarca( context, marcaValidar))
            {
                var marca = context.Marcas.
                    Where(b => b.nombre_marca.Equals(marcaValidar.nombre_marca)).
                    First();
                this.listaMarcas.Add(marca);
                return true;   
            }
            return false;
        }

        public bool validarEspaciosBlancos(string texto)
        {
            var cantidad_espacios = 0;
            foreach (var caracter in texto)
            {
                if (caracter.Equals(' '))
                {
                    cantidad_espacios++;
                    Console.WriteLine(caracter); 
                }
            }

            if (cantidad_espacios == texto.Length)
            {
                return true;
            }

            return false;
        }

        public bool validarExistenciaTaller(IRCVDbContext context,TallerDTO tallerValidar)
        {
            if (context.Talleres.Any(x => x.nombre_taller == tallerValidar.nombre_taller && 
                                                    x.direccion.Equals(tallerValidar.direccion) &&
                                                    x.RIF.Equals(tallerValidar.RIF)
                )
                )
            {
                return true;   
            }

            return false;
        }

        public void crearTallerEntity(TallerDTO T)
        {
            var i2=0;
            var MC=new MarcaCarroEntity();
            foreach (var marcaCarro in T.Marcac_Carros)
            {
                if (!AsignarMarcaExistente(_context, marcaCarro))
                {
                    MC=new MarcaCarroEntity();
                    MC.nombre_marca = marcaCarro.nombre_marca;
                    MC.CreatedAt=DateTime.Now;
                    MC.CreatedBy = null;
                    MC.UpdatedAt = null;
                    MC.UpdatedBy = null;
                    listaMarcas.Add(MC);
                    _context.Marcas.Add(MC);
                    i2=_context.DbContext.SaveChanges();   
                }
            }
            this.Taller.marcas=listaMarcas;
            this.Taller.direccion = T.direccion;
            this.Taller.estado = T.estado;
            this.Taller.nombre_taller = T.nombre_taller;
            this.Taller.RIF = T.RIF;
            this.Taller.CreatedAt=DateTime.Now;
            this.Taller.UpdatedAt = null;
            this.Taller.CreatedBy = null;
            this.Taller.UpdatedBy = null;
        }

        public int CreateTaller(TallerDTO taller)
        {
            var i=0;
            try
            {
                if (validarExistenciaTaller(_context,taller) == true)
                {
                    error++;
                    mensajeError = "No se puede crear este taller porque ya existe";
                    throw new RCVExceptions(mensajeError);
                }
                if ((String.IsNullOrEmpty(taller.direccion)||validarEspaciosBlancos(taller.direccion)) ||
                    (String.IsNullOrEmpty(taller.nombre_taller)||validarEspaciosBlancos(taller.nombre_taller)) ||
                    (String.IsNullOrEmpty(taller.RIF)||validarEspaciosBlancos(taller.RIF)) ||
                    taller.Marcac_Carros.Count==0)
                {
                    error++;
                    mensajeError = "No se puede crar un taller si alguno de estos datos esta vacio:nombre del taller, direccrioon, RIF y marcas de carros";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    crearTallerEntity(taller);
                    var data = _context.Talleres.Add(this.Taller);
                    i=_context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }
            return i;
        }*/
    }
}