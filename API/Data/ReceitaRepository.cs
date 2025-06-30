using System;

namespace API.Data;

public class ReceitaRepository : IReceitaRepository
{
    private readonly List<Receita> _receitas = new List<Receita>();
    private int _nextId = 1;

    public IEnumerable<Receita> GetAll()
    {
        return _receitas;
    }

    public Receita GetById(int id)
    {
        return _receitas.FirstOrDefault(r => r.Id == id);
    }

    public void Add(Receita receita)
    {
        receita.Id = _nextId++;
        _receitas.Add(receita);
    }

    public void Update(Receita receita)
    {
        var existing = GetById(receita.Id);
        if (existing != null)
        {
            existing.Nome = receita.Nome;
            existing.Ingredientes = receita.Ingredientes;
            existing.ModoPreparo = receita.ModoPreparo;
        }
    }

    public void Delete(int id)
    {
        var receita = GetById(id);
        if (receita != null)
            _receitas.Remove(receita);
    }
}