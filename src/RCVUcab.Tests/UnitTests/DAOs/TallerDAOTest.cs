using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backendRCVUcab.Exceptions;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using MockQueryable.Moq;
using Newtonsoft.Json;
using RCVUcab.Tests.DataSeed;
using RCVUcabBackend.BussinesLogic.DTOs;
using Xunit;

namespace RCVUcab.Tests.UnitTests.DAOs
{
    public class TallerDAOTest
    {
        private readonly TallerDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<TallerDAO>> _mockLogger;
        
        public TallerDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<TallerDAO>>();
            
            _dao = new TallerDAO(_contextMock.Object);
        }
        
        [Fact]
        public Task CrearTallerConMarcaNuevaResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests;
            var result = _dao.CreateTaller(taller);
            
            Assert.Equal(1,result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(2));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task CrearTallerConMarcaYaCreadaResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests3;
            taller.Marcac_Carros[0].nombre_marca = "Toyota";
            var result = _dao.CreateTaller(taller);
            
            Assert.Equal(1,result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task CrearTallerEjecutandoLaExceptionDeDatosVaciosResultadoFallido()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests1;
            taller.direccion = "";
            taller.RIF = "";
            taller.nombre_taller = "";
            taller.Marcac_Carros.RemoveAt(0);
            var result = Assert.Throws<RCVExceptions>(()=>_dao.CreateTaller(taller));
            Assert.Equal("No se puede crar un taller si alguno de estos datos esta vacio:nombre del taller, direccrioon, RIF y marcas de carros",result.Mensaje);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task CrearTallerEjecutandoLaExceptionDeTallerExistenteResultadoFallido()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests1;
            taller.nombre_taller = "Taller Mocaco";
            taller.direccion = "Valencia";
            taller.Marcac_Carros.Add(new MarcaDTO
            {
                nombre_marca = "Toyota"
            });
            taller.RIF = "J-458965785";
            var result = Assert.Throws<RCVExceptions>(()=>_dao.CreateTaller(taller));
            Assert.Equal("No se puede crear este taller porque ya existe",result.Mensaje);
            return Task.CompletedTask;
        }

    }
}