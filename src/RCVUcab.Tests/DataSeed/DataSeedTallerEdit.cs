using System;
using System.Collections.Generic;
using System.Linq;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcab.Tests.DataSeed
{
    public static class DataSeedTallerEdit
    {
        public static Mock<DbSet<TallererEntity>> mockSetTaller = new Mock<DbSet<TallererEntity>>();
        public static Mock<DbSet<MarcaCarroEntity>> mockSetMarca = new Mock<DbSet<MarcaCarroEntity>>();

        
        public static TallerDTO requests = new TallerDTO
        {
            nombre_taller = "Taller Lib",
            direccion = "Caracas, Catia, 234",
            RIF = "J-85756426",
            estado = CheckEstadoTaller.Activo,
            Marcac_Carros = new List<MarcaDTO>
            {
                new MarcaDTO()
                {
                    nombre_marca = "Toyota 4"
                }

            }
        };
        
        public static TallerDTO requests1 = new TallerDTO
        {
            nombre_taller = "Taller Lugis",
            direccion = "Caracas, catia, Calle Argentina",
            RIF = "J-1536478952",
            estado = CheckEstadoTaller.Activo,
            Marcac_Carros = new List<MarcaDTO>
            {
                new MarcaDTO()
                {
                    nombre_marca = "Toyota 2"
                }

            }
        };
        
        public static TallerDTO requests3 = new TallerDTO
        {
            nombre_taller = "Taller Mario",
            direccion = "Caracas, Catia, Calle colombia 234",
            RIF = "J-9823456",
            estado = CheckEstadoTaller.Activo,
            Marcac_Carros = new List<MarcaDTO>
            {
                new MarcaDTO()
                {
                    nombre_marca = "Toyota 3"
                }

            }
        };


        public static TallererEntity requestEliminateExcep = new TallererEntity
        {
            Id = new Guid("765711ae-9ebb-4eb5-8643-664f04a00efe"),
            CreatedAt = DateTime.Now,
            CreatedBy = null,
            UpdatedAt = null,
            UpdatedBy = null,
            nombre_taller = "Taller Mocaco",
            direccion = "Valencia",
            cumplimiento = 0,
            RIF = "J-458965785",
            estado = CheckEstadoTaller.Activo,
            marcas = new List<MarcaCarroEntity>
            {
                new MarcaCarroEntity
                {
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    CreatedAt = DateTime.Now,
                    CreatedBy = null,
                    UpdatedAt = null,
                    UpdatedBy = null,
                    nombre_marca = "Toyota"
                }

            }
        };
        
        public static TallererEntity requestEditExcep = new TallererEntity
        {
            Id = new Guid("765711ae-9ebb-4eb5-8643-664f04a00efe"),
            CreatedAt = DateTime.Now,
            CreatedBy = null,
            UpdatedAt = null,
            UpdatedBy = null,
            nombre_taller = "Taller Mocaco",
            direccion = "Valencia",
            cumplimiento = 0,
            RIF = "J-458965785",
            estado = CheckEstadoTaller.Activo,
            marcas = new List<MarcaCarroEntity>
            {
                new MarcaCarroEntity
                {
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    CreatedAt = DateTime.Now,
                    CreatedBy = null,
                    UpdatedAt = null,
                    UpdatedBy = null,
                    nombre_marca = "Toyota"
                }

            }
        };

        public static List<TallererEntity> requests2 = new List<TallererEntity>
        {
            new TallererEntity
            {
                Id = new Guid("9f1605fb-5a6a-4779-b289-1f9abfc942b0"),
                CreatedAt = DateTime.Now,
                CreatedBy = null,
                UpdatedAt = null,
                UpdatedBy = null,
                nombre_taller = "Taller Mocaco",
                direccion = "Valencia",
                cumplimiento = 0,
                RIF = "J-458965785",
                estado = CheckEstadoTaller.Activo,
                marcas = new List<MarcaCarroEntity>
                {
                    new MarcaCarroEntity
                    {
                        Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        CreatedAt = DateTime.Now,
                        CreatedBy = null,
                        UpdatedAt = null,
                        UpdatedBy = null,
                        nombre_marca = "Toyota"
                    }

                }
            },
            new TallererEntity
            {
                Id = new Guid("80460e0b-99bf-4807-8266-48b895c71af0"),
                CreatedAt = DateTime.Now,
                CreatedBy = null,
                UpdatedAt = null,
                UpdatedBy = null,
                nombre_taller = "Taller A",
                direccion = "B",
                cumplimiento = 0,
                RIF = "J-91753654",
                estado = CheckEstadoTaller.Activo,
                marcas = new List<MarcaCarroEntity>
                {
                    new MarcaCarroEntity
                    {
                        Id = new Guid("d7b4e2bf-f63e-44bb-bae5-0242f997e0cd"),
                        CreatedAt = DateTime.Now,
                        CreatedBy = null,
                        UpdatedAt = null,
                        UpdatedBy = null,
                        nombre_marca = "Toyota C"
                    }

                }
            }

        };
        
        public static List<AnalisisEntity> requestsAnalisis1 = new List<AnalisisEntity>
        {
            new AnalisisEntity
            {
                Id = new Guid("9f1605fb-5a6a-4779-b289-1f9abfc942b0"),
                CreatedAt = DateTime.Now,
                CreatedBy = null,
                UpdatedAt = null,
                UpdatedBy = null,
                id_usuario_taller = new Guid("80460e0b-99bf-4807-8266-48b895c71af0"),
                titulo_analisis = "Valencia",
                estado = CheckEstadoAnalisisAccidente.Pendiente,
                piezas = new List<PiezasEntity>
                {
                    new PiezasEntity
                    {
                        Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        CreatedAt = DateTime.Now,
                        CreatedBy = null,
                        UpdatedAt = null,
                        UpdatedBy = null,
                        descripcion_pieza="a",
                        id_marcca_pieza = new Guid("bd3db73b-3a92-45c6-a8eb-15f5e9c26c9a"),
                        estado = CheckEstadoPieza.reparar,
                        precio = 45.8,
                    }

                }
            }
        };
        
        


        public static void SetupDbContextData(this Mock<IRCVDbContext> _mockCOntext, string tipo)
        {
            var requestsMarcas = requests2.SelectMany(q => q.marcas).Concat(new List<MarcaCarroEntity>
            {
            });

            var requestsPiezas = requestsAnalisis1.SelectMany(q => q.piezas).Concat(new List<PiezasEntity>
            {
            });

            _mockCOntext.Setup(c => c.Marcas).Returns(mockSetMarca.Object);
            _mockCOntext.Setup(c => c.Talleres).Returns(mockSetTaller.Object);
            _mockCOntext.Setup(c => c.Marcas).Returns(requestsMarcas.AsQueryable().BuildMockDbSet().Object);
            _mockCOntext.Setup(c => c.Talleres).Returns(requests2.AsQueryable().BuildMockDbSet().Object);

            _mockCOntext.Setup(c => c.Analisis).Returns(requestsAnalisis1.AsQueryable().BuildMockDbSet().Object);
            _mockCOntext.Setup(c => c.Piezas).Returns(requestsPiezas.AsQueryable().BuildMockDbSet().Object);

            _mockCOntext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
        }
    }
}