using API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly List<Despesa> _despesas = new List<Despesa>();

        public async Task<IEnumerable<Despesa>> GetAll(string usuarioId)
        {
            return await Task.FromResult(_despesas.Where(d => d.UsuarioId == usuarioId));
        }

        public async Task<Despesa> GetById(int id, string usuarioId)
        {
            var despesa = _despesas.FirstOrDefault(d => d.Id == id && d.UsuarioId == usuarioId);
            return await Task.FromResult(despesa);
        }

        public async Task<Despesa> Add(Despesa despesa)
        {
            despesa.Id = _despesas.Count + 1;
            _despesas.Add(despesa);
            return await Task.FromResult(despesa);
        }

        public async Task Update(Despesa despesa)
        {
            var existingDespesa = _despesas.FirstOrDefault(d => d.Id == despesa.Id);
            if (existingDespesa != null)
            {
                existingDespesa.Descricao = despesa.Descricao;
                existingDespesa.Valor = despesa.Valor;
                existingDespesa.DataPagamento = despesa.DataPagamento;
            }

            await Task.CompletedTask;
        }

        public async Task<bool> Delete(int id, string usuarioId)
        {
            var despesa = _despesas.FirstOrDefault(d => d.Id == id && d.UsuarioId == usuarioId);
            if (despesa != null)
            {
                _despesas.Remove(despesa);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
