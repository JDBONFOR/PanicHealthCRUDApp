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
    public class PacienteController : ControllerBase
    {
        private readonly PacienteRepository _pacienteRepository = null;

        // Constructor
        public PacienteController(PacienteRepository PacienteRepository)
        {
            _pacienteRepository = PacienteRepository;
        }

        // GET api/profesionales
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var pacientes = _pacienteRepository.GetPaciente();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
