using MockQueryable.Moq;
using Moq;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace administradorTest.DataSeed
{
    public static class DataSeedPoliza
    {
        public static Mock<DbSet<PolizaEntity>> mockSetPoliza = new Mock<DbSet<PolizaEntity>>();
        public static void SetupDbContextDataPoliza(this Mock<IRCVDbContext> _mockContext)
        {
            var requests = new List<PolizaEntity>
            {
                new PolizaEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6"),
                    tipo = "Completa",
                    vencimiento = DateTime.Parse("20/01/2024"), 
                    asegurado = new List<AseguradoEntity>()
                    {
                        new AseguradoEntity
                        {
                            Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c1"),
                            ci = 25872770,
                            primer_n = "Adrián",
                            segundo_n = "David",
                            primer_a = "García",
                            segundo_a = "Espinoza",
                            sexo = 'm'
                        },
                    },
                    incidentes = new List<IncidentesEntity>()
                    {
                        new IncidentesEntity()
                        {
                            Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c2"),
                            descripcion = "Incidente por colisión en Chacao",
                            ubicacion = "Chaco, Miranda",
                            fecha = DateTime.Parse("28/06/2022"), 
                            poliza = new List<PolizaEntity>(){}
                        },
                        new IncidentesEntity()
                        {
                            Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c3"),
                            descripcion = "Incidente por desperfecto mecánico",
                            ubicacion = "San Antonio, Miranda",
                            fecha = DateTime.Parse("01/03/2022"), 
                            poliza = new List<PolizaEntity>(){}
                        }
                    },
                },
                new PolizaEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c4"),
                    tipo = "Completa",
                    vencimiento = DateTime.Parse("20/01/2023"), 
                    asegurado = new List<AseguradoEntity>()
                    {
                        new AseguradoEntity
                        {
                            Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c5"),
                            ci = 25872770,
                            primer_n = "Adrián",
                            segundo_n = "David",
                            primer_a = "García",
                            segundo_a = "Espinoza",
                            sexo = 'm'
                        }
                    },
                    incidentes = new List<IncidentesEntity>()
                    {
                    },
                },
            };
            _mockContext.Setup(c => c.poliza).Returns(mockSetPoliza.Object);
            _mockContext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.poliza).Returns(requests.AsQueryable().BuildMockDbSet().Object);
        }
    }
}