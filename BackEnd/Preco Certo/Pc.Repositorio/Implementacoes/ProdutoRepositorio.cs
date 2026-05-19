using Microsoft.EntityFrameworkCore;
using Pc.Dominio.Entities.Catalogo;
using Pc.Infraestrutura;
using Pc.Repositorio.Interfaces;

namespace Pc.Repositorio.Implementacoes
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Produto>> ListarPorLojaAsync(Guid? lojaId = null)
        {
            var query = _context.Produtos.AsQueryable();

            if (lojaId.HasValue)
                query = query.Where(p => p.LojaId == lojaId);

            return await query.OrderBy(p => p.NomeProduto).ToListAsync();
        }

        public async Task<List<Produto>> BuscarPorNomeAsync(string nome, Guid? lojaId = null)
        {
            var termo = nome.Trim().ToLower();
            var query = _context.Produtos
                .Where(p => p.NomeProduto.ToLower().Contains(termo)
                    || (p.Marca != null && p.Marca.ToLower().Contains(termo))
                    || (p.Descricao != null && p.Descricao.ToLower().Contains(termo)));

            if (lojaId.HasValue)
                query = query.Where(p => p.LojaId == lojaId);

            return await query.OrderBy(p => p.NomeProduto).ToListAsync();
        }
    }
}
