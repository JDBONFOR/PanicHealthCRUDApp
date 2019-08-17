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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository = null;

        // Constructor
        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var usuarios = _usuarioRepository.GetUsers();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_usuarioRepository.GetUsersById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Usuario> Post(Usuario user)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                _usuarioRepository.CreateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Usuario> Put(int id, [FromBody] JObject jsonEntity)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                var user = _usuarioRepository.UpdateUser(id, jsonEntity);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            try
            {
                // El form debe venir en formato JSON, con todo el modelo completo de datos.
                var user = _usuarioRepository.DeleteUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
