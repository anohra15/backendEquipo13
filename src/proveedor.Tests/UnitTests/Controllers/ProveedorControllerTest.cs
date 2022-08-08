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
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Controllers.Proveedor;
using RCVUcabBackend.Persistence.DAOs.Interfaces;
using RCVUcabBackend.Tests.DataSeed;
using Xunit;

namespace RCVUcab.Tests.UnitTests.Controllers


{
    public class ProveedorControllerTest
    {/*
        private readonly ProveedorController _controller;
        private readonly Mock<IProveedorDAO> _serviceMock;
        private readonly Mock<ILogger<ProveedorController>> _loggerMock;

        public ProveedorControllerTest()
        {
            _loggerMock = new Mock<ILogger<ProveedorController>>();
            _serviceMock = new Mock<IProveedorDAO>();
            _controller = new ProveedorController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        [Fact(DisplayName = "Crear proveedor exitosamente")]
        public Task CrearProveedorExitosamente()
        {
            _serviceMock.Setup(x => x.CreateProveedor(It.IsAny<ProveedorDTO>())).Returns(1);
            var result = _controller.CreateProveedor(DataSeedProveedor.requests1);
            Assert.Equal(1,result.DataInsert);
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Excepcion por datos vacios")]
        public Task CreateProveedorConDatosVaciosError()    
        {
            _serviceMock.Setup(x => x.CreateProveedor(It.IsAny<ProveedorDTO>())).Throws(new Exception("No se puede crar un proveedor si alguno de estos datos esta vacio:nombre del proveedor, direccion, telefono y marcas"));
            var result = _controller.CreateProveedor(DataSeedProveedor.requests1);
            Assert.Equal("No se puede crar un proveedor si alguno de estos datos esta vacio:nombre del proveedor, direccion, telefono y marcas",result.Message);
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Ejecutar exception de proveedor registrado")]
        public Task CreateTallerYaExistenteError()
        {
            _serviceMock.Setup(x => x.CreateProveedor(It.IsAny<ProveedorDTO>())).Throws(new Exception("No se puede crear este taller porque ya existe"));
            var result = _controller.CreateProveedor(DataSeedProveedor.requests1);
            Assert.Equal("No se puede crear este proveedor porque ya existe",result.Message);
            return Task.CompletedTask;
        }*/
    }
}