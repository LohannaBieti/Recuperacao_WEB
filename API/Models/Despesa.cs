using System;

namespace API.Models;

public class Despesa
{
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string UsuarioId { get; set; }
}
