using System;
using System.Linq;
using perito.BussinesLogic.DTOs;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Database;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Implementations
{
    public class PeritoDAO : IPeritoDAO
    {
        public readonly IRCVDbContext _context;
        public UsuarioPeritoEntity Perito = new UsuarioPeritoEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado";
        

        public PeritoDAO(IRCVDbContext context)
        {
            _context = context;
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
        
        public bool validarExistenciaPerito(IRCVDbContext context,PeritoDTO peritoValidar)
        {
            if (context.peritos.Any(x => x.nombres == peritoValidar.nombres && 
                                          x.apellidos.Equals(peritoValidar.apellidos) &&
                                          x.email.Equals(peritoValidar.email) &&
                                          x.contrasena.Equals(peritoValidar.contrasena)
                )
               )
            {
                return true;   
            }

            return false;
        }
        
        public void crearPeritoEntity(PeritoDTO T)
        {
            var i2=0;
            
            this.Perito.nombres=T.nombres;
            this.Perito.apellidos = T.apellidos;
            this.Perito.email = T.email;
            this.Perito.contrasena = T.contrasena;
            this.Perito.CreatedAt=DateTime.Now;
            this.Perito.UpdatedAt = null;
            this.Perito.CreatedBy = null;
            this.Perito.UpdatedBy = null;
        }
        
        public int CreatePerito(PeritoDTO perito)
        {
            var i=0;
            try
            {
                if (validarExistenciaPerito(_context,perito) == true)
                {
                    error++;
                    mensajeError = "No se puede crear este perito porque ya existe";
                    throw new RCVExceptions(mensajeError);
                }
                if ((String.IsNullOrEmpty(perito.nombres)||validarEspaciosBlancos(perito.nombres)) ||
                    (String.IsNullOrEmpty(perito.apellidos)||validarEspaciosBlancos(perito.apellidos)) ||
                    (String.IsNullOrEmpty(perito.email)||validarEspaciosBlancos(perito.email)) ||
                    (String.IsNullOrEmpty(perito.contrasena)||validarEspaciosBlancos(perito.contrasena)) )
                    
                {
                    error++;
                    mensajeError = "No se puede crar un perito si alguno de estos datos esta vacio:nombres del perito, apellidos del perito, email y contrasena de perito";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    crearPeritoEntity(perito);
                    var data = _context.peritos.Add(this.Perito);
                    i=_context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }
            return i;
        }
        
        
        
        public int ActualizarPerito(PeritoDTO perito, string email)
        {
            var i=0;
            try
            {
                if ((String.IsNullOrEmpty(perito.nombres)||validarEspaciosBlancos(perito.nombres)) ||
                    (String.IsNullOrEmpty(perito.apellidos)||validarEspaciosBlancos(perito.apellidos)) ||
                    (String.IsNullOrEmpty(perito.email)||validarEspaciosBlancos(perito.email)) ||
                    (String.IsNullOrEmpty(perito.contrasena)||validarEspaciosBlancos(perito.contrasena)) )
                    
                {
                    error++;
                    mensajeError = "No se puede actualizar un perito si alguno de estos datos esta vacio:nombres del perito, apellidos del perito, email y contrasena de perito";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    var peritoActualiza = _context.peritos.Find(email);
                    peritoActualiza.nombres=perito.nombres;
                    peritoActualiza.apellidos = perito.apellidos;
                    peritoActualiza.email = perito.email;
                    peritoActualiza.contrasena = perito.contrasena;
                    peritoActualiza.CreatedAt= DateTime.Now;
                    peritoActualiza.UpdatedAt = DateTime.Now;
                    peritoActualiza.CreatedBy = null;
                    peritoActualiza.UpdatedBy = null;
                    i=_context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }
            return i;
        }

      
        
    }
}