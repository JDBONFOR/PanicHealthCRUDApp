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
    public class ObraSocialController : ControllerBase
    {
        private readonly ObraSocialRepository _obraSocialRepository = null;

        // Constructor
        public ObraSocialController(ObraSocialRepository obraSocialRepository)
        {
            _obraSocialRepository = obraSocialRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var ObrasSociales = _obraSocialRepository.GetObraSocial();
                return Ok(ObrasSociales);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
