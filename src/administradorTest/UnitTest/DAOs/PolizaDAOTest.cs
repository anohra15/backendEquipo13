using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administradorTest.DataSeed;
using System.Linq;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;
using Xunit;
using PolizaDAO = administrador.Persistence.DAOs.Implementations.PolizaDAO;
namespace administradorTest.UnitTest.DAOs
{
    public class PolizaDAOTest
    {
        private readonly PolizaDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<PolizaDAO>> _mockLogger;

        public PolizaDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<PolizaDAO>>();
            _dao = new PolizaDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataPoliza();
        }
        
        /*Pruebo si puedo agregar una polizaSimple (sin incidentes)*/
        [Theory (DisplayName = "Valida que SÍ me inserta una poliza nueva")]
        [InlineData("Completa")] 
        public Task CreatePolicyTrue(String tipo)
        {
            PolizaSimpleDTO policy = new PolizaSimpleDTO()
            {
                tipo = tipo,
                vencimiento = DateTime.Parse("20/01/2024"), 
                asegurado = new List<AseguradoEntity>(){
                    new AseguradoEntity
                    {
                        Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6"),
                        ci = 25872770,
                        primer_n = "Adrián",
                        segundo_n = "David",
                        primer_a = "García",
                        segundo_a = "Espinoza",
                        sexo = 'm'
                    }
                }
            };
            String result = _dao.createPoliza(policy, tipo);
            String expected = "Poliza creada con éxito";
            Assert.Equal(expected,result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        /*valida que no me inserte una poliza nueva (Excepción)*/
        [Fact(DisplayName = "Valida que NO me inserte una poliza nueva")] //acá debería traer una excepcion
        public Task CreatePolicyFalse()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.createPoliza(null,null)); 
            Assert.Equal(result.Mensaje, "No se puede crear la poliza");
            return Task.CompletedTask;
        }
        
       /*desactiva poliza*/ 
        [Theory (DisplayName = "Desactivar poliza")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de92c6")]
        public Task desactivarPolizaTrue(Guid guid)
        {
            Mock<PolizaEntity> polizaId = new Mock<PolizaEntity>();
            Mock<PolizaEntity> poliza = new Mock<PolizaEntity>();
            poliza.Setup(p => p.Id).Returns(guid);
            var result = _dao.DeletePolicy(poliza.Object);
            Assert.True(result.Result);
            return Task.CompletedTask;
        }
        
        /*EVAUACIÓN INDIVIDUAL EN CLASE TRAER POLIZAS CON FECHA DE VENCIMIENTO*/
        [Fact (DisplayName = "Trae polizas compradas en 2020")]
        public Task getPolizaTrue()
        {
            var fecha = DateTime.Parse("01/01/2021"); //todas con fecha de vencimiento 2021
            var result = _dao.getPolicy(fecha);
            Assert.True(result.Any()); 
            return Task.CompletedTask; 
        }
    }
}