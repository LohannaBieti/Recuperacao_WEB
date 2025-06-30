using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/receitaFinanceira")]
    [Authorize] 
        public class ReceitaFinanceiraController : ControllerBase
    {
        private readonly IReceitaFinanceiraRepository _repository;

        public ReceitaFinanceiraController(IReceitaFinanceiraRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var receitas = await _repository.GetAll();
            return Ok(receitas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var receita = await _repository.GetById(id);
            if (receita == null) return NotFound();

            return Ok(receita);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReceitaFinanceira receita)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            receita.UsuarioId = User.Identity.Name;
            var novaReceita = await _repository.Add(receita);
            return CreatedAtAction(nameof(GetById), new { id = novaReceita.Id }, novaReceita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReceitaFinanceira receita)
        {
            if (id != receita.Id) return BadRequest("IDs não coincidem");

            var receitaExistente = await _repository.GetById(id);
            if (receitaExistente == null) return NotFound();

            await _repository.Update(receita);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _repository.Delete(id);
            if (!sucesso) return NotFound();

            return NoContent();
        }
    }

}
