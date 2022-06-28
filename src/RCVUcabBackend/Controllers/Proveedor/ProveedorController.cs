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
        private readonly IProveedorDAO _proveedorDao;
        private readonly ILogger<ProveedorController> _logger;
        
        public ProveedorController(ILogger<ProveedorController> logger, IProveedorDAO proveedorDao)
        {
            _proveedorDao = proveedorDao;
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
        
/*
        [HttpPost("create/taller")]
        public ApplicationResponse<ProveedorDTO> createProveedor([Required][FromBody]ProveedorDTO proveedorDto)
        {
            var ressponse = new ApplicationResponse<ProveedorDTO>();
            try
            {
                ressponse.DataInsert = _tallerDAO.CreateTaller(tallerDto);
                ressponse.Message = "se registro exitosamente";
                ressponse.Data = tallerDto;
                if (!ModelState.IsValid)
                {
                    ressponse.Success = false;
                    return ressponse;
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
*/
    }
}