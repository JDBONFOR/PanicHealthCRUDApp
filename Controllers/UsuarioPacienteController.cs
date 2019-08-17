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
    public class UsuarioPacienteController : ControllerBase
    {
        private readonly UsuarioPacienteRepository _usuarioPacienteRepository = null;

        // Constructor
        public UsuarioPacienteController(UsuarioPacienteRepository usuarioPacienteRepository)
        {
            _usuarioPacienteRepository = usuarioPacienteRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var usuarioPaciente = _usuarioPacienteRepository.GetUsuarioPaciente();
                return Ok(usuarioPaciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
