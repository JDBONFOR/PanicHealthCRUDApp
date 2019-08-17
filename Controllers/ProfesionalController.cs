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
    public class ProfesionalController : ControllerBase
    {
        private readonly ProfesionalRepository _profesionalRepository = null;

        // Constructor
        public ProfesionalController(ProfesionalRepository profesionalRepository)
        {
            _profesionalRepository = profesionalRepository;
        }

        // GET api/profesionales
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var profesionales = _profesionalRepository.GetProfesional();
                return Ok(profesionales);
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
            return Ok(_profesionalRepository.GetProfesionalById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Profesional> Post(Profesional profesional)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                _profesionalRepository.CreateProfesional(profesional);
                return Ok(profesional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Profesional> Put(int id, [FromBody] JObject jsonEntity)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                var profesional = _profesionalRepository.UpdateProfesional(id, jsonEntity);
                return Ok(profesional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Profesional> Delete(int id)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                var profesional = _profesionalRepository.DeleteProfesional(id);
                return Ok(profesional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}
