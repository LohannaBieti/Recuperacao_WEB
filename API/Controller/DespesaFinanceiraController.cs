using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/despesas")]
    [Authorize] // Garante que apenas usuários autenticados podem acessar
    public class DespesaFinanceiraController : ControllerBase
    {
        private readonly IDespesaRepository _repository;

        public DespesaFinanceiraController(IDespesaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string usuarioId = User?.Identity?.Name;
            var despesas = await _repository.GetAll(usuarioId);
            return Ok(despesas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            string usuarioId = User?.Identity?.Name;
            var despesa = await _repository.GetById(id, usuarioId);
            if (despesa == null)
                return NotFound(new { mensagem = "Despesa não encontrada." });

            return Ok(despesa);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Despesa despesa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            despesa.UsuarioId = User?.Identity?.Name;
            var novaDespesa = await _repository.Add(despesa);

            return CreatedAtAction(nameof(GetById), new { id = novaDespesa.Id }, novaDespesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Despesa despesa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != despesa.Id)
                return BadRequest(new { mensagem = "ID da URL não corresponde ao ID da despesa." });

            var existente = await _repository.GetById(id, User?.Identity?.Name);
            if (existente == null)
                return NotFound(new { mensagem = "Despesa não encontrada para este usuário." });

            await _repository.Update(despesa);
            return NoContent();
        }

        // DELETE: api/despesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string usuarioId = User?.Identity?.Name;
            var sucesso = await _repository.Delete(id, usuarioId);

            if (!sucesso)
                return NotFound(new { mensagem = "Despesa não encontrada para exclusão." });

            return NoContent();
        }
    }
}
