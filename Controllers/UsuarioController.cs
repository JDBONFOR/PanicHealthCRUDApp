using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanicHealth.Models;
using PanicHealth.Repository;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace PanicHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository = null;
        private readonly DbSet<Usuario> _useraccount = null;

        // Constructor
        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET - Get All Users Method
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

        // GET - Get Unique User Method
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_usuarioRepository.GetUsersById(id));
        }

        // POST - New User Method.
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

        // PUT - Update User Method
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

        // DELETE - Delete User Method
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

        // POST - ForgotPassword User Method
        [HttpPost]
        [Route("forgotpassword/{dni}")]
        public async Task<IActionResult> ForgotPassword(string dni)
        {
            try
            {
                //NO ENVIO EMAIL EN EL REQUEST
                if (string.IsNullOrEmpty(dni))
                    return BadRequest("Debe completar el mail para recuperar su contraseña.");

                var user = await this._useraccount.FirstOrDefaultAsync(us => us.usu_dni == dni);

                //NO EXISTE USER CON ESE MAIL
                if (user == null)
                    return NotFound("No existe un usuario con esa cuenta en nuestra base de datos.");

                var message = "Te enviamos un correo electrónico a la dirección " + user.usu_email + " con un link al que deberás ingresar para cambiar tu contraseña.";

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error, vuelva a intentarlo nuevamente.");
            }
        }

        // GET - Get Login User Method
        [HttpGet("validateuser/{dni}/{pass}")]
        public ActionResult<string> Get(string dni, string pass)
        {
            try
            {
                var user = _usuarioRepository.ValidateUser(dni);

                //NO EXISTE USER CON ESE MAIL
                if (user == null)
                    return StatusCode(998, "No existe un usuario con esa cuenta en nuestra base de datos.");

                //NO EXISTE USER CON ESE MAIL
                if (user.usu_password != pass)
                {
                    return StatusCode(999, "La password ingresada no coincide o es incorrecta");
                } else
                {
                    return Ok(user);
                }   

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error, vuelva a intentarlo nuevamente.");
            }
            
        }

    }
}
