using Pc.Dominio.Entities.Base;
using Pc.Dominio.Entities.Interacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pc.Dominio.Entities.Usuarios
{
    public class Cliente : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public decimal? LatitudeAtual { get; set; }
        public decimal? LongitudeAtual { get; set; }
        public ICollection <Favorito> Favoritos { get; set; } = new List<Favorito>();
        public ICollection<HistoricoPesquisa> HistoricosPesquisa { get; set; } = new List<HistoricoPesquisa>();
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
        public ICollection<PreferenciaCliente> Preferencias { get; set; } = new List<PreferenciaCliente>();
    }
}
