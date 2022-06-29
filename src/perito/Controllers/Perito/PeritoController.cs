using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using perito.BussinesLogic.DTOs;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Responses;

namespace perito.Controllers.Perito
{
    [ApiController]
    [Route("perito")]
    public class PeritoController : Controller
    {
        private readonly IPeritoDAO _peritoDAO;
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger, IPeritoDAO peritoDAO)
        {
            _peritoDAO = peritoDAO;
            _logger = logger;

        }

        [HttpPost("create/perito")]

        public ApplicationResponse<PeritoDTO> createPerito([Required] [FromRoute] PeritoDTO peritoDTO)
        {
            var response = new ApplicationResponse<PeritoDTO>();
            try
            {
                response.DataInsert = _peritoDAO.CreatePerito(peritoDTO);
                response.Message = "se registro exitosamente";
                response.Data = peritoDTO;
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut("Actualizar/{email}")]

        public ApplicationResponse<PeritoDTO> updatePerito(PeritoDTO peritoDTO, [Required] [FromRoute] string email)
        {
            var response = new ApplicationResponse<PeritoDTO>();
            try
            {
                response.DataInsert = _peritoDAO.ActualizarPerito(peritoDTO,email);
                response.Message = "se actualizo exitosamente";
                response.Data = peritoDTO;
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}