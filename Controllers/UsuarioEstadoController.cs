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
    public class UsuarioEstadoController : ControllerBase
    {
        private readonly UsuarioEstadoRepository _usuarioEstadoRepository = null;

        // Constructor
        public UsuarioEstadoController(UsuarioEstadoRepository usuarioEstadoRepository)
        {
            _usuarioEstadoRepository = usuarioEstadoRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var estadoUsuarios = _usuarioEstadoRepository.GetUsuarioEstado();
                return Ok(estadoUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
