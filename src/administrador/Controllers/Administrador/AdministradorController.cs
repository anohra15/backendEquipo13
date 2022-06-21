using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using administrador.BussinesLogic.DTOs;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("provider")]
    public class ProviderController : Controller
    {
        private readonly IAdministradorDAO _adminDAO;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(ILogger<ProviderController> logger, IAdministradorDAO providerDAO)
        {
            //_adminDAO = AdministradorDAO;
            _logger = logger;
        }

        [HttpGet("providers/{brand}")]
        public ApplicationResponse<List<AdminDTO>> GetProvidersByBrand([Required][FromRoute] string brand)
        {
            var response = new ApplicationResponse<List<AdminDTO>>();
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