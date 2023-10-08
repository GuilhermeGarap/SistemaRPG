using Microsoft.AspNetCore.Mvc;
using ApiRpg.Models;
using ApiRpg.Data;

namespace ApiRpg.Controllers
{
    [ApiController]
    [Route("api/classe")]
    public class ClasseController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public ClasseController(AppDataContext context)
        {
            _ctx = context;
        }

        // GET: api/classe/listar
        [HttpGet]
        [Route("listar")]
        public ActionResult<IEnumerable<Classe>> Listar()
        {
            try
            {
                List<Classe> classes = _ctx.Classes.ToList();
                return Ok(classes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/classe/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public ActionResult Buscar([FromRoute] int id)
        {
            try
            {
                Classe classe = _ctx.Classes.Find(id);

                if (classe != null)
                {
                    return Ok(classe);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/classe/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public ActionResult Cadastrar([FromBody] Classe classe)
        {
            try
            {
                // Verifica se o valor do AtributoBonus é válido
                if (!IsValidAtributoBonus(classe.AtributoBonus))
                {
                    return BadRequest("Valor inválido para o atributo 'AtributoBonus'.");
                }

                _ctx.Classes.Add(classe);
                _ctx.SaveChanges();
                return Created("", classe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/classe/alterar/{id}
        [HttpPut]
        [Route("alterar/{id}")]
        public ActionResult Alterar([FromRoute] int id, [FromBody] Classe classeAtualizada)
        {
            try
            {
                Classe classeExistente = _ctx.Classes.Find(id);

                if (classeExistente != null)
                {
                    // Verifica se o valor do AtributoBonus é válido
                    if (!IsValidAtributoBonus(classeAtualizada.AtributoBonus))
                    {
                        return BadRequest("Valor inválido para o atributo 'AtributoBonus'.");
                    }

                    classeExistente.Nome = classeAtualizada.Nome;
                    classeExistente.AtributoBonus = classeAtualizada.AtributoBonus;

                    _ctx.SaveChanges();
                    return Ok(classeExistente);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/classe/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public ActionResult Deletar([FromRoute] int id)
        {
            try
            {
                Classe classeExistente = _ctx.Classes.Find(id);

                if (classeExistente != null)
                {
                    _ctx.Classes.Remove(classeExistente);
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

        // Função para verificar se o AtributoBonus é válido
        private bool IsValidAtributoBonus(string atributoBonus)
        {
            // Lista de valores permitidos
            List<string> valoresPermitidos = new List<string>
            {
                "Vigor", "Força", "Sabedoria", "Presença", "Agilidade"
            };

            return valoresPermitidos.Contains(atributoBonus);
        }
    }
}
