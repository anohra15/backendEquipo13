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
    [Route("provider")]
    public class PeritoController : Controller
    {
        private readonly IPeritoDAO _peritoDAO;
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger, IPeritoDAO provider)
        {
            //_ adminDAO = AdministradorDAO;
            _logger = logger;

        }

        [HttpGet("providers/{brand}")]

        public ApplicationResponse<List<PeritoDTO>> GerProviderByBrand([Required] [FromRoute] string brand)
        {
            var response = new ApplicationResponse<List<PeritoDTO>>();
            try
            {
                //response.Data = _adminDAO.GetProvidersByBrand(brand);
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }

            return response;
        }
    }
}
