using System;

using API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly List<Receita> _receitas = new List<Receita>();

        public async Task<IEnumerable<Receita>> GetAll(string usuarioId)
        {
            return await Task.FromResult(_receitas.Where(r => r.UsuarioId == usuarioId));
        }

        public async Task<Receita> GetById(int id, string usuarioId)
        {
            var receita = _receitas.FirstOrDefault(r => r.Id == id && r.UsuarioId == usuarioId);
            return await Task.FromResult(receita);
        }

        public async Task<Receita> Add(Receita receita)
        {
            receita.Id = _receitas.Count + 1;
            _receitas.Add(receita);
            return await Task.FromResult(receita);
        }

        public async Task Update(Receita receita)
        {
            var existingReceita = _receitas.FirstOrDefault(r => r.Id == receita.Id);
            if (existingReceita != null)
            {
                existingReceita.Descricao = receita.Descricao;
                existingReceita.Valor = receita.Valor;
                existingReceita.DataRecebimento = receita.DataRecebimento;
            }

            await Task.CompletedTask;
        }

        public async Task<bool> Delete(int id, string usuarioId)
        {
            var receita = _receitas.FirstOrDefault(r => r.Id == id && r.UsuarioId == usuarioId);
            if (receita != null)
            {
                _receitas.Remove(receita);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
