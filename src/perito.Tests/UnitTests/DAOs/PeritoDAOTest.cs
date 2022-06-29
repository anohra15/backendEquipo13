using System.Threading.Tasks;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using perito.Exceptions;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.Database;
using perito.Tests.DataSeed;
using System.Collections.Generic;
using System.ComponentModel;
using MockQueryable.Moq;
using Newtonsoft.Json;
using Xunit;

namespace perito.Tests.UnitTests.DAOs
{
    public class PeritoDAOTest
    {
        private readonly PeritoDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<PeritoDAO>> _mockLogger;
        
        public PeritoDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<PeritoDAO>>();
            
            _dao = new PeritoDAO(_contextMock.Object);
        }
        
        [Fact]
        public Task CrearPeritoNuevoResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var perito = DataSeedPeritoEdit.requests;
            var result = _dao.CreatePerito(perito);
            
            Assert.Equal(1,result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(2));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ActualizarPeritoNuevoResultadoExitoso()
        {
            string email = "javier@gmail.com";
            _contextMock.SetupDbContextData("update");
            var perito = DataSeedPeritoEdit.requests;
            var result = _dao.ActualizarPerito(perito,email);
            
            Assert.Equal(1,result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(2));
            return Task.CompletedTask;
        }
        
       
      
        
        [Fact]
        public Task CrearTallerEjecutandoLaExceptionDeDatosVaciosResultadoFallido()
        {
            _contextMock.SetupDbContextData("insert");
            var perito = DataSeedPeritoEdit.requests1;
            perito.nombres = "";
            perito.apellidos = "";
            perito.email = "";
            perito.contrasena = "";
            var result = Assert.Throws<RCVExceptions>(()=>_dao.CreatePerito(perito));
            Assert.Equal("No se puede crar un perito si alguno de estos datos esta vacio:nombres del perito, apellidos, email y contrasena de perito",result.Mensaje);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task CrearPeritoEjecutandoLaExceptionDePeritoExistenteResultadoFallido()
        {
            _contextMock.SetupDbContextData("insert");
            var perito = DataSeedPeritoEdit.requests1;
            perito.nombres = "Ruben Luis";
            perito.apellidos = "Dario Martinez";
            perito.email = "ruben@gmail.com";
            perito.contrasena = "963258";
            var result = Assert.Throws<RCVExceptions>(()=>_dao.CreatePerito(perito));
            Assert.Equal("No se puede crear este taller porque ya existe",result.Mensaje);
            return Task.CompletedTask;
        }
    }
}