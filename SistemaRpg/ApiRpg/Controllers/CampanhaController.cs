using Microsoft.AspNetCore.Mvc;
using ApiRpg.Models;
using ApiRpg.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiRpg.Controllers
{
    [ApiController]
    [Route("api/campanha")]
    public class CampanhaController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public CampanhaController(AppDataContext context)
        {
            _ctx = context;
        }

        // GET: api/campanha/listar
        [HttpGet]
        [Route("listar")]
        public ActionResult<IEnumerable<Campanha>> Listar()
        {
            try
            {
                List<Campanha> campanhas = _ctx.Campanhas
                    .Include(c => c.Fichas)
                    .ToList();

                return Ok(campanhas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/campanha/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public ActionResult Buscar([FromRoute] int id)
        {
            try
            {
                Campanha campanha = _ctx.Campanhas
                    .Include(c => c.Fichas)
                    .FirstOrDefault(c => c.CampanhaId == id);

                if (campanha != null)
                {
                    return Ok(campanha);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/campanha/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public ActionResult Cadastrar([FromBody] Campanha campanha)
        {
            try
            {
                if (campanha.Fichas == null)
                {
                    campanha.Fichas = new List<Ficha>();
                }

                _ctx.Campanhas.Add(campanha);
                _ctx.SaveChanges();
                return Created("", campanha);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/campanha/alterar/{id}
        [HttpPut]
        [Route("alterar/{id}")]
        public ActionResult Alterar([FromRoute] int id, [FromBody] Campanha campanhaAtualizada)
        {
            try
            {
                Campanha campanhaExistente = _ctx.Campanhas.Find(id);

                if (campanhaExistente != null)
                {
                    campanhaExistente.Nome = campanhaAtualizada.Nome;
                    campanhaExistente.Sinopse = campanhaAtualizada.Sinopse;

                    _ctx.SaveChanges();
                    return Ok(campanhaExistente);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/campanha/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public ActionResult Deletar([FromRoute] int id)
        {
            try
            {
                Campanha campanhaExistente = _ctx.Campanhas.Find(id);

                if (campanhaExistente != null)
                {
                    _ctx.Campanhas.Remove(campanhaExistente);
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
