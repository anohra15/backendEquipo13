using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using perito.BussinesLogic.DTOs;
using perito.Controllers.Perito;
using perito.Persistence.DAOs.Interfaces;
using perito.Tests.DataSeed;
using Xunit;

namespace perito.Tests.UnitTests.Controllers
{
    public class PeritoControllerTest
    {
        private readonly PeritoController _controller;
        private readonly Mock<IPeritoDAO> _serviceMock;
        private readonly Mock<IDireccionDAO> _serviveMock2;
        
        private readonly Mock<ILogger<PeritoController>> _loggerMock;
        private string email = "prueba@hotmail.com";

        public PeritoControllerTest()
        {
            _loggerMock = new Mock<ILogger<PeritoController>>();
            _serviceMock = new Mock<IPeritoDAO>();
            _controller = new PeritoController(_loggerMock.Object, _serviceMock.Object, _serviveMock2.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        [Fact(DisplayName = "Crear perito exitosamente")]
        public Task CrearPeritoExitosamente()
        {
            _serviceMock.Setup(x => x.CreatePerito(It.IsAny<PeritoDTO>())).Returns(1);
            var result = _controller.createPerito(DataSeedPeritoEdit.requests1);
            Assert.Equal(1,result.DataInsert);
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Actualizar perito exitosamente")]
        public Task ActualizarPeritoExitosamente()
        {
            _serviceMock.Setup(x => x.ActualizarPerito(It.IsAny<PeritoDTO>(),email)).Returns(1);
            var result = _controller.updatePerito(DataSeedPeritoEdit.requests,email);
            Assert.Equal(1,result.DataInsert);
            return Task.CompletedTask;
        }
        
       
        
        [Fact(DisplayName = "Ejecutar exception de crear peritos por datos vacios")]
        public Task CreatePeritosConDatosVaciosError()    
        {
            _serviceMock.Setup(x => x.CreatePerito(It.IsAny<PeritoDTO>())).Throws(new Exception("No se puede crear un perito si alguno de estos datos esta vacio:nombre del perito, apellido del perito, email y contrasena de perito"));
            var result = _controller.createPerito(DataSeedPeritoEdit.requests1);
            Assert.Equal("No se puede crar un perito si alguno de estos datos esta vacio:nombre del perito, apellido del perito, email y contrasena de perito",result.Message);
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Ejecutar exception de crear perito que ya esta registrado")]
        public Task CreatePeritoYaExistenteError()
        {
            _serviceMock.Setup(x => x.CreatePerito(It.IsAny<PeritoDTO>())).Throws(new Exception("No se puede crear este perito porque ya existe"));
            var result = _controller.createPerito(DataSeedPeritoEdit.requests1);
            Assert.Equal("No se puede crear este perito porque ya existe",result.Message);
            return Task.CompletedTask;
        }
    }
}