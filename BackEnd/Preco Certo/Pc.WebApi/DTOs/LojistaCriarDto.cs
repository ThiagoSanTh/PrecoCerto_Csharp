namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para registrar novo lojista (signup)
    /// Consolidado - sem intermediário Usuario
    /// </summary>
    public class LojistaCriarDto
    {
        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email (deve ser único)</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Senha (mínimo 6 caracteres)</summary>
        public string Senha { get; set; } = string.Empty;

        /// <summary>Telefone (opcional)</summary>
        public string? Telefone { get; set; }

        /// <summary>ID da loja que o lojista gerencia</summary>
        public Guid LojaId { get; set; }

        /// <summary>Cargo/posição (gerente, vendedor, estoquista, etc)</summary>
        public string? Cargo { get; set; }
    }
}
