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

        public async Task<List<Loja>> ListarLojasAsync(string nome)
        {
            return await _context.Lojas
                .Where(l => l.NomeFantasia.ToLower().Contains(nome.ToLower())).ToListAsync();
        }

        public async Task<Loja?> ObterLojaPorIdAsync(Guid id)
        {
            return await _context.Lojas.FindAsync(id);
        }

        public async Task<Loja> AdicionarLojaAsync(Loja loja)
        {
            _context.Lojas.Add(loja);
            await _context.SaveChangesAsync();
            return loja;
        }

        public async Task<Loja> RemoverLojaAsync(Guid id)
        {
            var loja = await _context.Lojas.FindAsync(id);
            if (loja == null)
            {
                throw new KeyNotFoundException("Loja não encontrada.");
            }
            _context.Lojas.Remove(loja);
            await _context.SaveChangesAsync();
            return loja;
        }
        public async Task<Loja> AtualizarLojaAsync(Loja loja)
        {
            var lojaExistente = await _context.Lojas.FindAsync(loja.Id);
            if (lojaExistente == null)
            {
                throw new KeyNotFoundException("Loja não encontrada.");
            }
            _context.Entry(lojaExistente).CurrentValues.SetValues(loja);
            await _context.SaveChangesAsync();
            return lojaExistente;
        }
    }
}
