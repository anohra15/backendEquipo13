using Microsoft.EntityFrameworkCore;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using administrador.Exceptions;
using administrador.BussinesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IUserDAO
    {
        public string createUser(UserDTO user);
    }
}