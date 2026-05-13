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
        Task<Loja?> ObterLojaPorIdAsync(Guid id);
        Task<List<Loja>> ListarLojasAsync();
        Task<List<Loja>> BuscarPorNomeAsync(string nome);
        Task AtualizarLojaAsync(Loja loja);
        Task RemoverLojaAsync(Guid id);
    }
}