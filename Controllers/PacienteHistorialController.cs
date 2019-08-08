using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PanicHealth.Models;
using PanicHealth.Repository;
using Newtonsoft.Json.Linq;

namespace PanicHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteHistorialController : ControllerBase
    {
        private readonly PacienteHistorialRepository _pacienteHistorialRepository = null;

        // Constructor
        public PacienteHistorialController(PacienteHistorialRepository pacienteHistorialRepository)
        {
            _pacienteHistorialRepository = pacienteHistorialRepository;
        }

        // GET api/profesionales
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var pacienteHistorial = _pacienteHistorialRepository.GetPacienteHistorial();
                return Ok(pacienteHistorial);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
