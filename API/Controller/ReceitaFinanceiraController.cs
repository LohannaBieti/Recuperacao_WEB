using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/receitas")]
    [Authorize]  
    public class ReceitaFinanceiraController : ControllerBase
    {
        private readonly IReceitaRepository _repository;

        public ReceitaFinanceiraController(IReceitaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarioId = User.Identity.Name; // Obtendo o ID do usuário autenticado
            var receitas = await _repository.GetAll(usuarioId);
            return Ok(receitas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuarioId = User.Identity.Name;
            var receita = await _repository.GetById(id, usuarioId);
            if (receita == null) return NotFound();
            return Ok(receita);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Receita receita)
        {
            var usuarioId = User.Identity.Name;
            receita.UsuarioId = usuarioId;
            var novaReceita = await _repository.Add(receita);
            return CreatedAtAction(nameof(GetById), new { id = novaReceita.Id }, novaReceita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Receita receita)
        {
            var usuarioId = User.Identity.Name;
            if (id != receita.Id) return BadRequest("IDs não coincidem");
            await _repository.Update(receita);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioId = User.Identity.Name;
            var sucesso = await _repository.Delete(id, usuarioId);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
