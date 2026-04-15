using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<List<Produto>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Produtos
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
        }
    }
}
