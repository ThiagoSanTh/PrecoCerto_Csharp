using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pc.Dominio.Entities.Estabelecimentos;

namespace Pc.Repositorio.Interfaces
{
    public interface ILojaRepositorio : IRepositorio<Loja>
    {
        Task<List<Loja>> BuscarPorNomeAsync(string nome);
        Task<List<Loja>> ListarLojasAsync(string nome);
        Task<Loja?> ObterLojaPorIdAsync(Guid id);
        Task<Loja> AdicionarLojaAsync(Loja loja);
        Task<Loja> RemoverLojaAsync(Guid id);
        Task<Loja> AtualizarLojaAsync(Loja loja);
    }
}
