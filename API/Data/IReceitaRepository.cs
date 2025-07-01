using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IReceitaRepository
    {
        Task<IEnumerable<Receita>> GetAll(string usuarioId);
        Task<Receita> GetById(int id, string usuarioId);
        Task<Receita> Add(Receita receita);
        Task Update(Receita receita);
        Task<bool> Delete(int id, string usuarioId);
    }
}
