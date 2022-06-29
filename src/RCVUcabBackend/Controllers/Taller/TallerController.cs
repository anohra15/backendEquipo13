using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using backendRCVUcab.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.Controllers.Taller
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("taller")]
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
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
        [HttpDelete("eliminar/taller/{id_taller}")]
        public ApplicationResponse<TallerDTO> eliminarTaller([Required][FromRoute]Guid id_taller)
        {
            var ressponse = new ApplicationResponse<TallerDTO>();
            try
            {
                ressponse.DataInsert = _tallerDAO.EliminarTaller(id_taller);
                ressponse.Message = "se elimino exitosamente el taller de id="+id_taller;
                ressponse.Data = null;
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
        [HttpPut("actualizar/taller/{id_taller}")]
        public ApplicationResponse<TallerDTO> editarTaller([Required][FromBody]TallerDTO tallerCambios,[Required][FromRoute]Guid id_taller)
        {
            var ressponse = new ApplicationResponse<TallerDTO>();
            try
            {
                ressponse.DataInsert = _tallerDAO.ActualizarTaller(tallerCambios,id_taller);
                ressponse.Message = "se edito exitosamente el taller de id="+id_taller;
                ressponse.Data = null;
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
        [HttpGet("consultar/requerimientosAsignados/{id_taller}")]
        public ApplicationResponse<List<AnalisisConsultaDTO>> consultarRequeimientosAsignados([Required][FromRoute]Guid id_taller)
        {
            var ressponse = new ApplicationResponse<List<AnalisisConsultaDTO>>();
            try
            {
                ressponse.Data = _tallerDAO.ConsultarRequerimientosAsignados(id_taller);
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
        [HttpGet("consultarFiltro/requerimientosAsignados/{id_taller}/{filtro_estado}")]
        public ApplicationResponse<List<AnalisisConsultaDTO>> consultarRequeimientosAsignadosFiltro([Required][FromRoute]Guid id_taller,[Required][FromRoute]CheckEstadoAnalisisAccidente filtro_estado)
        {
            var ressponse = new ApplicationResponse<List<AnalisisConsultaDTO>>();
            try
            {
                ressponse.Data = _tallerDAO.ConsultarRequerimientosAsignadosPorFiltro(id_taller,filtro_estado);
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }

        
    }
}