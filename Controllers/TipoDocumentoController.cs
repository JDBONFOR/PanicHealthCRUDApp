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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly TipoDocumentoRepository _tipoDocumentooRepository = null;

        // Constructor
        public TipoDocumentoController(TipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentooRepository = tipoDocumentoRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var tipoDocumentos = _tipoDocumentooRepository.GetTipoDocumento();
                return Ok(tipoDocumentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
