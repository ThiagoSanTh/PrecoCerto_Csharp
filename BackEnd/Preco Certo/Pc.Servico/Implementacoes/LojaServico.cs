using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pc.Dominio.Entities.Estabelecimentos;
using Pc.Repositorio.Interfaces;
using Pc.Servico.Interfaces;

namespace Pc.Servico.Implementacoes
{
    public class LojaService : ILojaServico
    {
        private readonly ILojaRepositorio _lojaRepositorio;

        public LojaService(ILojaRepositorio lojaRepositorio)
        {
            _lojaRepositorio = lojaRepositorio;
        }

        public async Task<Loja> AdicionarAsync(Loja loja)
        {
            if (string.IsNullOrWhiteSpace(loja.NomeFantasia))
                throw new Exception("O nome fantasia da loja é obrigatório.");

            return await _lojaRepositorio.AdicionarAsync(loja);
        }

        public async Task<Loja?> ObterLojaPorIdAsync(Guid id)
        {
            return await _lojaRepositorio.ObterPorIdAsync(id);
        }

        public async Task<List<Loja>> ListarLojasAsync()
        {
            return await _lojaRepositorio.ListarAsync();
        }

        public async Task<List<Loja>> BuscarPorNomeAsync(string nome)
        {
            return await _lojaRepositorio.BuscarPorNomeAsync(nome);
        }

        public async Task AtualizarLojaAsync(Loja loja)
        {
            if (string.IsNullOrWhiteSpace(loja.NomeFantasia))
                throw new Exception("O nome fantasia da loja é obrigatório.");

            await _lojaRepositorio.AtualizarAsync(loja);
        }

        public async Task RemoverLojaAsync(Guid id)
        {
            await _lojaRepositorio.RemoverAsync(id);
        }

    }
}