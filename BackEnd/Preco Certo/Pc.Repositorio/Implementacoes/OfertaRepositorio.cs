using Microsoft.EntityFrameworkCore;
using Pc.Dominio.Entities.Catalogo;
using Pc.Dominio.Entities.Estabelecimentos;
using Pc.Infraestrutura;
using Pc.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Repositorio.Implementacoes
{
    public class OfertaRepositorio : Repositorio<Oferta>, IOfertaRepositorio
    {
        public OfertaRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Oferta>> ObterPorProdutoAsync(Guid produtoId)
        {
            return await _context.Ofertas
                .Include(o => o.Produto)
                .Include(o => o.Loja)
                .Where(o => o.ProdutoId == produtoId)
                .ToListAsync();
        }
    }
}