using Pc.Dominio.Entities.Catalogo;

namespace Pc.Servico.Interfaces
{
    public interface IProdutoServico
    {
        Task<Produto> AdicionarAsync(Produto produto);
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task<List<Produto>> ListarProdutosAsync(Guid? lojaId = null);
        Task<List<Produto>> BuscarPorNomeAsync(string nome, Guid? lojaId = null);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(Guid id);
    }
}