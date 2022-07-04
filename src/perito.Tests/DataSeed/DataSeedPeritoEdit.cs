using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using perito.BussinesLogic.DTOs;
using perito.Persistence.Database;
using perito.Persistence.Entities;

namespace perito.Tests.DataSeed
{
    public static class DataSeedPeritoEdit
    {
         public static Mock<DbSet<UsuarioPeritoEntity>> mockSetPerito = new Mock<DbSet<UsuarioPeritoEntity>>();
         public static Mock<DbSet<DireccionEntity>> mockSetDireccion = new Mock<DbSet<DireccionEntity>>();
         
         
        
        public static PeritoDTO requests = new PeritoDTO
        {
            nombres = "Javier Jose",
            apellidos = "Flores Carpio",
            email = "javier@gmail.com",
            contrasena = "1234",
        };
        
        public static PeritoDTO requests1 = new PeritoDTO
        {
            nombres = "Luis Miguel",
            apellidos = "Martinez Perez",
            email = "miguel@gmail.com",
            contrasena = "321",
        };
        
        public static PeritoDTO requests3 = new PeritoDTO
        {
            nombres = "Ana Maria",
            apellidos = "Gonzalez Gonzalez",
            email = "ana@gmail.com",
            contrasena = "9874",
        };

        public static List<UsuarioPeritoEntity> requests2 = new List<UsuarioPeritoEntity>
        {
            new UsuarioPeritoEntity()
            {
                Id = new Guid("9f1605fb-5a6a-4779-b289-1f9abfc942b0"),
                CreatedAt = DateTime.Now,
                CreatedBy = null,
                UpdatedAt = null,
                UpdatedBy = null,
                nombres = "Ruben Luis",
                apellidos = "Dario Martinez",
                email = "ruben@gmail.com",
                contrasena = "963258",
                
            }

        };

        public static void SetupDbContextData(this Mock<IRCVDbContext> _mockCOntext, string tipo)
        {
            
            _mockCOntext.Setup(c => c.peritos).Returns(mockSetPerito.Object);
            _mockCOntext.Setup(c => c.peritos).Returns(requests2.AsQueryable().BuildMockDbSet().Object);
            _mockCOntext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
        }
    }
}