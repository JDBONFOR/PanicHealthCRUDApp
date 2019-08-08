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

        
    }
}
