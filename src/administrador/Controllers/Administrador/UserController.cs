using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using administrador.BussinesLogic.DTOs;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using administrador.Persistence.DAOs.Implementations;
using Microsoft.AspNetCore.Identity;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserDAO _userDAO;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserDAO userDAO)
        {
            _userDAO = userDAO;
            _logger = logger;
        }

        [HttpPost("adduser")]
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
        }
    }
}