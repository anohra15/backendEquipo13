using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using administrador.BussinesLogic.DTOs;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Asegurado")]
    public class AseguradoController : Controller
    {
        private readonly IAseguradoDAO _aseguradoDAO;
        private readonly ILogger<AseguradoController> _logger;

        public AseguradoController(ILogger<AseguradoController> logger, IAseguradoDAO insuredDAO)
        {
            _aseguradoDAO = insuredDAO;
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> AddInsured([FromBody] AseguradoDTO insured) //add insured
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _aseguradoDAO.createInsured(insured);
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        [HttpPost("Consultar-All")]
        public ApplicationResponse<List<PAseguradoDTO>> GetInsured([FromBody] PAseguradoDTO insured) //get all insured
        {
            var response = new ApplicationResponse<List<PAseguradoDTO>>();
            try
            {
                response.Data = _aseguradoDAO.getInsured();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        /*[HttpPost("adduser")]
        public ApplicationResponse<string> AddUser([FromBody] UserDTO user)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _userDAO.createUser(user);
                Console.WriteLine("Dame data ",  response.Data);
            }
            catch (RCVExceptions ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadGateway;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/
    }
}