using MockQueryable.Moq;
using Moq;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using administrador.Persistence.DAOs.Implementations;
using Microsoft.EntityFrameworkCore;

namespace administradorTest.DataSeed
{
    public static class DataSeedAsegurado
    {
        public static Mock<DbSet<AseguradoEntity>> mockSetAsegurado = new Mock<DbSet<AseguradoEntity>>();
        public static void SetupDbContextDataAsegurado(this Mock<IRCVDbContext> _mockContext)
        {
            var requests = new List<AseguradoEntity>
            {
                new AseguradoEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6"),
                    ci = 25872770,
                    primer_n = "Adrián",
                    segundo_n = "David",
                    primer_a = "García",
                    segundo_a = "Espinoza",
                    sexo = 'm'
                },
                new AseguradoEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de74a9"),
                    ci = 24872336,
                    primer_n = "Andrea",
                    segundo_n = "Yamelis",
                    primer_a = "Lopez",
                    segundo_a = "Obrador",
                    sexo = 'f'
                }
            };
            _mockContext.Setup(c => c.asegurado).Returns(mockSetAsegurado.Object);
           _mockContext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
           _mockContext.Setup(c => c.asegurado).Returns(requests.AsQueryable().BuildMockDbSet().Object);
            //_mockContext.Setup(c => c.asegurado).Returns(requestsInsured.AsQueryable().BuildMockDbSet().Object);
        }
    }
}