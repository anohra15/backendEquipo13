using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.Tests.DataSeed;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Implementations;
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
            var result = Assert.Throws<ExcepcionTaller>(()=>_dao.CreateTaller(taller));
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
            var result = Assert.Throws<ExcepcionTaller>(()=>_dao.CreateTaller(taller));
            Assert.Equal("No se puede crear este taller porque ya existe",result.Mensaje);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task EliminarTallerResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests2[0];
            var i=_dao.EliminarTaller(taller.Id);
            Assert.Equal(i,1);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task EliminarTallerEjecutandoLaExcepcionDeTallerNoRegistrado()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requestEliminateExcep;
            var result = Assert.Throws<ExcepcionTaller>(()=>_dao.EliminarTaller(taller.Id));
            Assert.Equal("No existe el talled",result.Mensaje);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ActualizarTallerResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests2[1];
            var editTaller = new TallerDTO()
            {
                nombre_taller = "G",
                direccion = "T"
            };
            var i=_dao.ActualizarTaller(editTaller,taller.Id);
            Assert.Equal(i,1);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ActualizarTallerEjecutandoLaExcepcionDeTallerNoRegistrado()
        {
            _contextMock.SetupDbContextData("insert");
            var editTaller = new TallerDTO()
            {
                nombre_taller = "G"
            };
            var taller = DataSeedTallerEdit.requestEditExcep;
            var result = Assert.Throws<ExcepcionTaller>(()=>_dao.ActualizarTaller(editTaller,taller.Id));
            Assert.Equal("No existe el talled",result.Mensaje);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ActualizarTallerConMarcaExistenteResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var editTaller = new TallerDTO()
            {
                Marcac_Carros = new List<MarcaDTO>
                {
                    new MarcaDTO {nombre_marca = "Toyota C"}
                }
            };
            var taller = DataSeedTallerEdit.requests2[0];
            var i=_dao.ActualizarTaller(editTaller,taller.Id);
            Assert.Equal(i,1);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ActualizarTallerConMarcaNoExistenteResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var editTaller = new TallerDTO()
            {
                Marcac_Carros = new List<MarcaDTO>
                {
                    new MarcaDTO {nombre_marca = "Toyota CD"}
                }
            };
            var taller = DataSeedTallerEdit.requests2[0];
            var i=_dao.ActualizarTaller(editTaller,taller.Id);
            Assert.Equal(i,1);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(2));
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ConsultarRquerimientosAsignadosResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests2[1];
            var i=_dao.ConsultarRequerimientosAsignados(taller.Id);
            Assert.NotEmpty(i);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ConsultarRquerimientosAsignadosPorFiltroResultadoExitoso()
        {
            _contextMock.SetupDbContextData("insert");
            var taller = DataSeedTallerEdit.requests2[1];
            var i=_dao.ConsultarRequerimientosAsignadosPorFiltro(taller.Id,CheckEstadoAnalisisAccidente.Pendiente);
            Assert.Equal(CheckEstadoAnalisisAccidente.Pendiente.ToString(),i[0].estado);
            return Task.CompletedTask;
        }
        
    }
}