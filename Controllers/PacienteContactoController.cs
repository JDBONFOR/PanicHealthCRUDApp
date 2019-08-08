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
    public class PacienteContactoController : ControllerBase
    {
        private readonly PacienteContactoRepository _pacienteContactoRepository = null;

        // Constructor
        public PacienteContactoController(PacienteContactoRepository pacienteContactoRepository)
        {
            _pacienteContactoRepository = pacienteContactoRepository;
        }

        // GET api/profesionales
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var pacienteContactos = _pacienteContactoRepository.GetPacienteContacto();
                return Ok(pacienteContactos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
