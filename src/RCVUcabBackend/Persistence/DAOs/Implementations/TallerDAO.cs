using System;
using System.Collections.Generic;
using System.Linq;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.Persistence.DAOs.Implementations
{

    public class TallerDAO: ITallerDAO
    {
        public readonly IRCVDbContext _context;
        public TallererEntity Taller=new TallererEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado ";
        public ICollection<MarcaCarroEntity> listaMarcas= new List<MarcaCarroEntity>();
        public ICollection<MarcaCarroEntity> listaMarcas2= new List<MarcaCarroEntity>();
        
        public TallerDAO(IRCVDbContext context)
        {
            _context = context;
        }

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

        public TallererEntity traerTallerA(IRCVDbContext context,Guid id_taller)
        {
            if (context.Talleres.Any(x => x.Id == id_taller ))
            {
                var taller = context.Talleres.
                    Where(b => b.Id==id_taller).
                    Single();
                return taller;
            }
            return null;
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
        }
        
        public int EliminarTaller(Guid id_taller)
        {
            var i=0;
            try
            {
                var data =traerTallerA(_context,id_taller);
                if (data==null)
                {
                    error++;
                    mensajeError = "No existe el talled";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    var a=_context.Talleres.Remove(data);
                    i=_context.DbContext.SaveChanges();   
                }
   
            }catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }
            return i;
        }
        
        public int ActualizarTaller(TallerDTO tallerCambios,Guid id_taller)
        {
            var i=0;
            try
            {
                var data =traerTallerA(_context,id_taller);
                if (data==null)
                {
                    error++;
                    mensajeError = "No existe el talled";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    if(!(String.IsNullOrEmpty(tallerCambios.direccion)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.direccion)))
                        {
                            data.direccion = tallerCambios.direccion;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(tallerCambios.nombre_taller)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.nombre_taller)))
                        {
                            data.nombre_taller = tallerCambios.nombre_taller;
                        }
                    }
                    if(!(String.IsNullOrEmpty(tallerCambios.RIF)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.RIF)))
                        {
                            data.RIF = tallerCambios.RIF;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(tallerCambios.RIF)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.RIF)))
                        {
                            data.estado = tallerCambios.estado;   
                        }
                    }

                    if (tallerCambios.Marcac_Carros != null)
                    {
                        if (tallerCambios.Marcac_Carros.Count != 0)
                        {
                            foreach (var marca in tallerCambios.Marcac_Carros)
                            {
                                if (!AsignarMarcaExistente(_context, marca))
                                {
                                    var MC = new MarcaCarroEntity();
                                    MC.nombre_marca = marca.nombre_marca;
                                    MC.CreatedAt = DateTime.Now;
                                    MC.CreatedBy = null;
                                    MC.UpdatedAt = null;
                                    MC.UpdatedBy = null;
                                    listaMarcas.Add(MC);
                                    _context.Marcas.Add(MC);
                                    i = _context.DbContext.SaveChanges();
                                    listaMarcas2.Add(MC);
                                }
                                else
                                {
                                    
                                    var marcaExistente = _context.Marcas
                                        .Where(b => b.nombre_marca.Equals(marca.nombre_marca)).First();
                                    this.listaMarcas2.Add(marcaExistente);
                                }
                            }
                            data.marcas=this.listaMarcas2;
                        }
                    }

                    _context.Talleres.Update(data);
                    i=_context.DbContext.SaveChanges();   
                }
   
            }catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }
            return i;
        }

        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignados(Guid id_taller)
        {
            try
            {
                var data = _context.Analisis.Include(b => b.piezas).Where(c => c.id_usuario_taller.Equals(id_taller))
                    .Select(b => new AnalisisConsultaDTO
                    {
                        titulo_analisis = b.titulo_analisis,
                        estado = b.estado.ToString()
                    }).ToList();
                return data;
            }
            catch (Exception e)
            {
                throw new RCVExceptions(mensajeError);
            }
        }
        
        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignadosPorFiltro(Guid id_taller,CheckEstadoAnalisisAccidente filtro)
        {
            try
            {
                var data = _context.Analisis.
                    Include(b => b.piezas).
                    Where(c => c.id_usuario_taller.Equals(id_taller)&&
                               c.estado==filtro)
                    .Select(b => new AnalisisConsultaDTO
                    {
                        titulo_analisis = b.titulo_analisis,
                        estado = b.estado.ToString()
                    }).ToList();
                return data;
            }
            catch (Exception e)
            {
                throw new RCVExceptions(mensajeError);
            }
        }
    }
}