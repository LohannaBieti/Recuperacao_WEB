using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDataContext _context;
    public CategoriaRepository(AppDataContext context)
    {
        _context = context;
    }

    public Categoria BuscarCategoriaPorId(int id)
    {
        return _context.Categorias.Find(id);
    }

    public void Cadastrar(Categoria categeoria)
    {
        _context.Categorias.Add(categeoria);
        _context.SaveChanges();
    }

    public List<Categoria> Listar()
    {
        return _context.Categorias.ToList();
    }
}