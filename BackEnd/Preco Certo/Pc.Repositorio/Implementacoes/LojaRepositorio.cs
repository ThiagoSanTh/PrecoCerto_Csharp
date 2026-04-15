using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pc.Dominio.Entities.Estabelecimentos;
using Pc.Infraestrutura;
using Pc.Repositorio.Interfaces;

namespace Pc.Repositorio.Implementacoes
{
    public class LojaRepositorio : Repositorio<Loja>, ILojaRepositorio
    {
        public LojaRepositorio(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Loja>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Lojas
                .Where(l => l.NomeFantasia.ToLower().Contains(nome.ToLower())).ToListAsync();
        }
    }
}
