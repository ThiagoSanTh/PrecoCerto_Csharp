namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de cliente
    /// Consolidado - sem intermediário Usuario
    /// </summary>
    public class ClienteRespostaDto
    {
        /// <summary>ID do cliente</summary>
        public Guid Id { get; set; }

        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Telefone</summary>
        public string? Telefone { get; set; }

        /// <summary>Tipo de usuário (implícito: Cliente)</summary>
        public int Tipo { get; set; }

        /// <summary>Última vez que fez login</summary>
        public DateTime? UltimoLogin { get; set; }

        /// <summary>Latitude atual (geolocalização)</summary>
        public decimal? LatitudeAtual { get; set; }

        /// <summary>Longitude atual (geolocalização)</summary>
        public decimal? LongitudeAtual { get; set; }

        /// <summary>Se cliente está ativo</summary>
        public bool Ativo { get; set; }

        /// <summary>Data de criação</summary>
        public DateTime DataCriacao { get; set; }
    }
}
