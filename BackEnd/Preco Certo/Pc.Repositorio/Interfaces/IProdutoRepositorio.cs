using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pc.Dominio.Entities.Catalogo;

namespace Pc.Repositorio.Interfaces
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<List<Produto>> BuscarPorNomeAsync(string nome);
    }
}
