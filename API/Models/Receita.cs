using System;

namespace API.Models;

public class Receita
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Ingredientes { get; set; }
    public string ModoPreparo { get; set; }

}
