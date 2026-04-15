using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pc.Repositorio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> AdicionarAsync(T entity);
        Task<T?> ObterPorIdAsync(Guid id);
        Task<List<T>> ListarAsync();
        Task AtualizarAsync(T entity);
        Task RemoverAsync(Guid id);
    }
}
