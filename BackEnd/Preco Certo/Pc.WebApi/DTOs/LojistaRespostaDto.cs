namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de lojista
    /// Consolidado - sem intermediário Usuario
    /// </summary>
    public class LojistaRespostaDto
    {
        /// <summary>ID do lojista</summary>
        public Guid Id { get; set; }

        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Telefone</summary>
        public string? Telefone { get; set; }

        /// <summary>Tipo de usuário (implícito: Lojista)</summary>
        public int Tipo { get; set; }

        /// <summary>Última vez que fez login</summary>
        public DateTime? UltimoLogin { get; set; }

        /// <summary>ID da loja gerenciada</summary>
        public Guid LojaId { get; set; }

        /// <summary>Nome da loja</summary>
        public string NomeLoja { get; set; } = string.Empty;

        /// <summary>Cargo/posição</summary>
        public string? Cargo { get; set; }

        /// <summary>Se lojista está ativo</summary>
        public bool Ativo { get; set; }

        /// <summary>Data de criação</summary>
        public DateTime DataCriacao { get; set; }
    }
}
