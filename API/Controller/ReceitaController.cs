using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/receita")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaRepository _repository;

    public ReceitaController(IReceitaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Receita>> Get()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Receita> Get(int id)
    {
        var receita = _repository.GetById(id);
        if (receita == null)
            return NotFound();
        return Ok(receita);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Receita receita)
    {
        _repository.Add(receita);
        return CreatedAtAction(nameof(Get), new { id = receita.Id }, receita);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Receita receita)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return NotFound();

        receita.Id = id;
        _repository.Update(receita);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
    }
}
