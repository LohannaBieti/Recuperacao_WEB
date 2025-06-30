using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; internal set; }
    public DbSet<ReceitaFinanceira> Receitas { get; internal set; }
}

