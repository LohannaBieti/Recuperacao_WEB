using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IDespesaRepository
    {
        Task<IEnumerable<Despesa>> GetAll(string usuarioId);
        Task<Despesa> GetById(int id, string usuarioId);
        Task<Despesa> Add(Despesa despesa);
        Task Update(Despesa despesa);
        Task<bool> Delete(int id, string usuarioId);
    }
}
