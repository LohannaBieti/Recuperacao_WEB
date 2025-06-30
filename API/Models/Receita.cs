namespace API.Models;

public class ReceitaFinanceira
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public string UsuarioId { get; set; }
}
