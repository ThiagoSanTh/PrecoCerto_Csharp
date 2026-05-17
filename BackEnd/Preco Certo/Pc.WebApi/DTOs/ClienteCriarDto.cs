namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para registrar novo cliente (signup)
    /// Consolidado - sem intermediário Usuario
    /// </summary>
    public class ClienteCriarDto
    {
        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email (deve ser único)</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Senha (mínimo 6 caracteres)</summary>
        public string Senha { get; set; } = string.Empty;

        /// <summary>Telefone (opcional)</summary>
        public string? Telefone { get; set; }

        /// <summary>Latitude inicial (opcional)</summary>
        public decimal? LatitudeAtual { get; set; }

        /// <summary>Longitude inicial (opcional)</summary>
        public decimal? LongitudeAtual { get; set; }
    }
}
