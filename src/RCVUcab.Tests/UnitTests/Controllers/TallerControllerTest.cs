using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backendRCVUcab.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using backendRCVUcab.Responses;
using Castle.Core.Logging;
using Moq;
using RCVUcab.Tests.DataSeed;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Controllers.Taller;
using RCVUcabBackend.Persistence.DAOs.Interfaces;
using Xunit;

namespace RCVUcab.Tests.UnitTests.Controllers


{
    public class TallerControllerTest
    {
        private readonly TallerController _controller;
        private readonly Mock<ITallerDAO> _serviceMock;
        private readonly Mock<ILogger<TallerController>> _loggerMock;

        public TallerControllerTest()
        {
            _loggerMock = new Mock<ILogger<TallerController>>();
            _serviceMock = new Mock<ITallerDAO>();
            _controller = new TallerController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        [Fact(DisplayName = "Crear taller exitosamente")]
        public Task CrearTallerExitosamente()
        {
            _serviceMock.Setup(x => x.CreateTaller(It.IsAny<TallerDTO>())).Returns(1);
            var result = _controller.createTaller(DataSeedTallerEdit.requests1);
            Assert.Equal(1,result.DataInsert);
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Ejecutar exception de crear taller por datos vacios")]
        public Task CreateTallerConDatosVaciosError()    
        {
            _serviceMock.Setup(x => x.CreateTaller(It.IsAny<TallerDTO>())).Throws(new Exception("No se puede crar un taller si alguno de estos datos esta vacio:nombre del taller, direccrioon, RIF y marcas de carros"));
            var result = _controller.createTaller(DataSeedTallerEdit.requests1);
            Assert.Equal("No se puede crar un taller si alguno de estos datos esta vacio:nombre del taller, direccrioon, RIF y marcas de carros",result.Message);
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Ejecutar exception de crear taller que ya esta registrado")]
        public Task CreateTallerYaExistenteError()
        {
            _serviceMock.Setup(x => x.CreateTaller(It.IsAny<TallerDTO>())).Throws(new Exception("No se puede crear este taller porque ya existe"));
            var result = _controller.createTaller(DataSeedTallerEdit.requests1);
            Assert.Equal("No se puede crear este taller porque ya existe",result.Message);
            return Task.CompletedTask;
        }
    }
}