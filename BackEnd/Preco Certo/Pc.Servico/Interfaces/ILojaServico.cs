using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pc.Dominio.Entities.Estabelecimentos;
using Pc.Infraestrutura;
using Pc.Repositorio.Interfaces;


namespace Pc.Servico.Interfaces
{
    public interface ILojaServico
    {
        Task<Loja> AdicionarAsync(Loja loja);
        Task<Loja?> ObterPorIdAsync(Guid id);
        Task<List<Loja>> ListarAsync();
        Task<List<Loja>> BuscarPorNomeAsync(string nome);
        Task AtualizarAsync(Loja loja);
        Task RemoverAsync(Guid id);
    }
}