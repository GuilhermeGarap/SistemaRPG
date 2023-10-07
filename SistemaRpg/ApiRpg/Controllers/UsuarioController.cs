using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRpg.Data;
using ApiRpg.Models;

namespace ApiRpg.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public UsuarioController(AppDataContext context)
        {
            _ctx = context;
        }

        // GET: api/usuario/listar
        [HttpGet]
        [Route("listar")]
        public ActionResult<IEnumerable<Usuario>> ListarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = _ctx.Usuarios.ToList();
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/usuario/buscar/{usuarioId}
        [HttpGet]
        [Route("buscar/{usuarioId}")]
        public ActionResult<Usuario> BuscarUsuario([FromRoute] int usuarioId)
        {
            try
            {
                Usuario usuario = _ctx.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/usuario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public ActionResult CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _ctx.Usuarios.Add(usuario);
                _ctx.SaveChanges();
                return Created("", usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/usuario/alterar/{id}
        [HttpPut]
        [Route("alterar/{id}")]
        public IActionResult Alterar([FromRoute] int id, [FromBody] Usuario usuario)
        {
            try
            {
                Usuario usuarioCadastrado = _ctx.Usuarios.FirstOrDefault(x => x.UsuarioId == id);

                if (usuarioCadastrado != null)
                {
                    usuarioCadastrado.Nome = usuario.Nome;
                    _ctx.Usuarios.Update(usuarioCadastrado);
                    _ctx.SaveChanges();
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // DELETE: api/usuario/deletar/{usuarioId}
        [HttpDelete]
        [Route("deletar/{usuarioId}")]
        public IActionResult DeletarUsuario([FromRoute] int usuarioId)
        {
            try
            {
                Usuario usuario = _ctx.Usuarios.Find(usuarioId);
                if (usuario != null)
                {
                    _ctx.Usuarios.Remove(usuario);
                    _ctx.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
