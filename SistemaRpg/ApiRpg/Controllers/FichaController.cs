using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRpg.Data;
using ApiRpg.Models;

namespace ApiRpg.Controllers
{
    [ApiController]
    [Route("api/ficha")]
    public class FichaController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public FichaController(AppDataContext context)
        {
            _ctx = context;
        }

        // GET: api/ficha/listar
        [HttpGet]
        [Route("listar")]
        public ActionResult<IEnumerable<Ficha>> ListarFichas()
        {
            try
            {
                List<Ficha> fichas = _ctx.Fichas
                    .Include(f => f.Classe)
                    .Include(f => f.Usuario)
                    .Include(f => f.Campanha)
                    .ToList();

                return Ok(fichas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/ficha/buscar/{fichaId}
        [HttpGet]
        [Route("buscar/{fichaId}")]
        public ActionResult<Ficha> BuscarFicha([FromRoute] int fichaId)
        {
            try
            {
                Ficha ficha = _ctx.Fichas
                    .Include(f => f.Classe)
                    .Include(f => f.Usuario)
                    .Include(f => f.Campanha)
                    .FirstOrDefault(f => f.FichaId == fichaId);

                if (ficha != null)
                {
                    return Ok(ficha);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/ficha/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public ActionResult CadastrarFicha([FromBody] Ficha ficha)
        {
            try
            {
                _ctx.Fichas.Add(ficha);
                _ctx.SaveChanges();
                return Created("", ficha);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ficha/alterar/{id}
        [HttpPut]
        [Route("alterar/{id}")]
        public IActionResult AlterarFicha([FromRoute] int id, [FromBody] Ficha ficha)
        {
            try
            {
                Ficha fichaCadastrada = _ctx.Fichas.FirstOrDefault(f => f.FichaId == id);

                if (fichaCadastrada != null)
                {
                    fichaCadastrada.Nome = ficha.Nome;
                    // Atualize outros campos conforme necessário
                    _ctx.Fichas.Update(fichaCadastrada);
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

        // DELETE: api/ficha/deletar/{fichaId}
        [HttpDelete]
        [Route("deletar/{fichaId}")]
        public IActionResult DeletarFicha([FromRoute] int fichaId)
        {
            try
            {
                Ficha ficha = _ctx.Fichas.Find(fichaId);
                if (ficha != null)
                {
                    _ctx.Fichas.Remove(ficha);
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
