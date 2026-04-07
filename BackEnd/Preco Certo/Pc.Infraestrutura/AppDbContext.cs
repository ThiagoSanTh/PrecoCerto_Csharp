using Microsoft.EntityFrameworkCore;
using Pc.Dominio.Entities.Catalogo;
using Pc.Dominio.Entities.Estabelecimentos;
using Pc.Dominio.Entities.Interacoes;
using Pc.Dominio.Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pc.Infraestrutura
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Lojista> Lojistas { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<HistoricoPesquisa> HistoricosPesquisa { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<PreferenciaCliente> PreferenciasClientes { get; set; }
    }
}

