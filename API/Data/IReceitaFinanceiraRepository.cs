using System;
using API.Models;

namespace API.Data;

public interface IReceitaRepository
{
    Receita GetById(int id);
    void Add(Receita receita);
    void Update(Receita receita);
    void Delete(int id);
    object? GetAll();
    void Add(Receita receita);
}
