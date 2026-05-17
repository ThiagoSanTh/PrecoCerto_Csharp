namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de usuário (sem expor senha)
    /// </summary>
    public class UsuarioRespostaDto
    {
        /// <summary>ID do usuário</summary>
        public Guid Id { get; set; }

        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Telefone</summary>
        public string? Telefone { get; set; }

        /// <summary>Tipo de usuário</summary>
        public int Tipo { get; set; }

        /// <summary>Data do último login</summary>
        public DateTime? UltimoLogin { get; set; }

        /// <summary>Se usuário está ativo</summary>
        public bool Ativo { get; set; }

        /// <summary>Data de criação</summary>
        public DateTime DataCriacao { get; set; }
    }
}
