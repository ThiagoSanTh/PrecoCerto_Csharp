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
    }
}
