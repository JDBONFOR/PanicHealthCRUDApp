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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_pacienteRepository.GetPacienteById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Paciente> Post(Paciente paciente)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                _pacienteRepository.CreatePaciente(paciente);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Paciente> Put(int id, [FromBody] JObject jsonEntity)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                var paciente = _pacienteRepository.UpdatePaciente(id, jsonEntity);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                var paciente = _pacienteRepository.DeletePaciente(id);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}
