using Pc.Dominio.Entities.Catalogo;
using Pc.Repositorio.Interfaces;
using Pc.Servico.Interfaces;

namespace Pc.Servico.Implementacoes
{
    public class ProdutoService : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<Produto> AdicionarAsync(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.NomeProduto))
                throw new Exception("O nome do produto é obrigatório.");

            return await _produtoRepositorio.AdicionarAsync(produto);
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await _produtoRepositorio.ObterPorIdAsync(id);
        }

        public async Task<List<Produto>> ListarProdutosAsync()
        {
            return await _produtoRepositorio.ListarAsync();
        }

        public async Task<List<Produto>> BuscarPorNomeAsync(string nome)
        {
            return await _produtoRepositorio.BuscarPorNomeAsync(nome);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.NomeProduto))
                throw new Exception("O nome do produto é obrigatório.");

            await _produtoRepositorio.AtualizarAsync(produto);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _produtoRepositorio.RemoverAsync(id);
        }
    }
}