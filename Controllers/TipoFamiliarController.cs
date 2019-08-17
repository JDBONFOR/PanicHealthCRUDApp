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
    public class TipoFamiliarController : ControllerBase
    {
        private readonly TipoFamiliarRepository _tipoFamiliarRepository = null;

        // Constructor
        public TipoFamiliarController(TipoFamiliarRepository tipoFamiliarRepository)
        {
            _tipoFamiliarRepository = tipoFamiliarRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var tipoFamiliar = _tipoFamiliarRepository.GetTipoFamiliar();
                return Ok(tipoFamiliar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
