using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pc.Dominio.Entities.Usuarios;
using Pc.Infraestrutura;
using Pc.Repositorio.Interfaces;

namespace Pc.Repositorio.Implementacoes
{
    /// <summary>
    /// Implementação do repositório para Cliente
    /// Herda do Repositorio genérico e implementa métodos específicos
    /// Inclui dados relacionados (Usuario) para evitar lazy loading
    /// </summary>
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        /// <summary>
        /// Construtor que injeta o contexto do banco de dados
        /// </summary>
        public ClienteRepositorio(AppDbContext context) : base(context)
        {
        }

    /// <summary>
    /// Obtém cliente por ID (consolidado - não precisa de Usuario)
    /// </summary>
    public override async Task<Cliente?> ObterPorIdAsync(Guid usuarioId)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == usuarioId && c.Ativo);
    }

    /// <summary>
    /// Obtém clientes por email (busca para login)
    /// Email é único por cliente
    /// </summary>
    public async Task<Cliente?> ObterPorEmailAsync(string email)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower() && c.Ativo);
    }

    /// <summary>
    /// Lista todos os clientes ativos
    /// </summary>
    public async Task<List<Cliente>> ListarAtivosAsync()
    {
        return await _context.Clientes
            .Where(c => c.Ativo)
            .ToListAsync();
    }

        /// <summary>
        /// Obtém clientes por proximidade usando geolocalização
        /// Calcula distância entre pontos (fórmula Haversine simplificada)
        /// OBS: Para escala, considere usar PostGIS (PostgreSQL extension)
        /// </summary>
        public async Task<List<Cliente>> ObterPorProximidadeAsync(decimal latitude, decimal longitude, decimal raioKm)
        {
            var clientes = await _context.Clientes
                .Where(c => c.Ativo)
                .ToListAsync();

            // Filtra em memória (não ideal em produção com muitos dados)
            // TODO: Migrar para PostGIS quando escalar
            var clientesProximos = clientes
                .Where(c => c.LatitudeAtual.HasValue && c.LongitudeAtual.HasValue)
                .Where(c => CalcularDistancia(
                    latitude, longitude,
                    c.LatitudeAtual.Value, c.LongitudeAtual.Value
                ) <= raioKm)
                .ToList();

            return clientesProximos;
        }

        /// <summary>
        /// Atualiza a localização atual do cliente
        /// </summary>
        public async Task AtualizarLocalizacaoAsync(Guid clienteId, decimal latitude, decimal longitude)
        {
            var cliente = await ObterPorIdAsync(clienteId);
            if (cliente != null)
            {
                cliente.LatitudeAtual = latitude;
                cliente.LongitudeAtual = longitude;
                await AtualizarAsync(cliente);
            }
        }

        /// <summary>
        /// Calcula distância entre dois pontos em km usando Haversine
        /// Aproximação: funciona bem para distâncias até ~100km
        /// </summary>
        private decimal CalcularDistancia(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            const decimal R = 6371m; // Raio da Terra em km

            var dLat = (lat2 - lat1) * (decimal)Math.PI / 180m;
            var dLon = (lon2 - lon1) * (decimal)Math.PI / 180m;
            var a = (decimal)Math.Sin((double)dLat / 2) * (decimal)Math.Sin((double)dLat / 2) +
                    (decimal)Math.Cos((double)lat1 * Math.PI / 180) * (decimal)Math.Cos((double)lat2 * Math.PI / 180) *
                    (decimal)Math.Sin((double)dLon / 2) * (decimal)Math.Sin((double)dLon / 2);
            var c = 2m * (decimal)Math.Atan2(Math.Sqrt((double)a), Math.Sqrt((double)(1 - a)));

            return R * c;
        }
    }
}
