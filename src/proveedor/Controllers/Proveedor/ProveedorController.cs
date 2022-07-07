using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;
using System.Text;


namespace RCVUcabBackend.Controllers.Taller
{
   [ApiController]
    [Route("proveedor")]
    public class ProveedorController : Controller
    {
        private readonly IProveedorDAO _proveedorDAO;
        private readonly ILogger<ProveedorController> _logger;
        
        public ProveedorController(ILogger<ProveedorController> logger, IProveedorDAO proveedorDAO)
        {
            _proveedorDAO = proveedorDAO;
            _logger = logger;
        }
        
     /*   [HttpGet("rabbit")]
        public ApplicationResponse<TallerDTO> rabbitMQ()
        {
            var ressponse = new ApplicationResponse<TallerDTO>();
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        ressponse.Message = "a" + message;
                                       Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: "hello",
                        autoAck: true,
                        consumer: consumer);
                }

                return ressponse;
            }
            catch (Exception ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Message;
                //ressponse.Exception = ex.Excepcion.ToString();
            }

            return ressponse;
        }
        */
        

        [HttpPost("create/proveedor")]
        public ApplicationResponse<ProveedorDTO> CreateProveedor([Required][FromBody]ProveedorDTO proveedorDto)
        {
            var ressponse = new ApplicationResponse<ProveedorDTO>();
            try
            {
                if (proveedorDto.tipoProveedor.tipo == "de_partes")
                {
                    ressponse.DataInsert = _proveedorDAO.CreateProveedor(proveedorDto);
                    ressponse.Message = "se registro exitosamente";
                    ressponse.Data = proveedorDto;
                    if (!ModelState.IsValid)
                    {
                        ressponse.Success = false;
                        return ressponse;
                    }
                }
                else
                {
                    ressponse.Success = false;
                    ressponse.Message = "Solo se admiten proveedores de partes";
                }
            }
            catch (Exception ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Message;
                //ressponse.Exception = ex.Excepcion.ToString();
            }
            return ressponse;
        }

    }
}