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
    public class UsuarioTipoController : ControllerBase
    {
        private readonly UsuarioTipoRepository _usuarioTipoRepository = null;

        // Constructor
        public UsuarioTipoController(UsuarioTipoRepository usuarioTipoRepository)
        {
            _usuarioTipoRepository = usuarioTipoRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var tipoUsuarios = _usuarioTipoRepository.GetUsuarioTipos();
                return Ok(tipoUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
