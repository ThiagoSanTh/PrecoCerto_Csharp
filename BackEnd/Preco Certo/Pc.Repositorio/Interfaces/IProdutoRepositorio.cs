using Pc.Dominio.Entities.Catalogo;

namespace Pc.Repositorio.Interfaces
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<List<Produto>> BuscarPorNomeAsync(string nome, Guid? lojaId = null);
        Task<List<Produto>> ListarPorLojaAsync(Guid? lojaId = null);
    }
}
