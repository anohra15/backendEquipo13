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
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RCVUcabBackend.Controllers.Taller
{
    [ApiController]
    [Route("taller")]
    public class TallerController:Controller
    {
        private readonly ITallerDAO _tallerDAO;
        private readonly ILogger<TallerController> _logger;
        
        public TallerController(ILogger<TallerController> logger, ITallerDAO tallerDAO)
        {
            _tallerDAO = tallerDAO;
            _logger = logger;
        }
    

    [HttpPost("create/taller")]
        public ApplicationResponse<TallerDTO> createTaller([Required][FromBody]TallerDTO tallerDto)
        {
            var ressponse = new ApplicationResponse<TallerDTO>();
            try
            {
                ressponse.DataInsert = _tallerDAO.CreateTaller(tallerDto);
                ressponse.Message = "se registro exitosamente";
                ressponse.Data = tallerDto;
            }
            catch (Exception ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Message;
            }
            return ressponse;
        }

    }
}