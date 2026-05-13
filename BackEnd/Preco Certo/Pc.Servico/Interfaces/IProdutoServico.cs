using Pc.Dominio.Entities.Catalogo;

namespace Pc.Servico.Interfaces
{
    public interface IProdutoServico
    {
        Task<Produto> AdicionarAsync(Produto produto);
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task<List<Produto>> ListarProdutosAsync();
        Task<List<Produto>> BuscarPorNomeAsync(string nome);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(Guid id);
    }
}