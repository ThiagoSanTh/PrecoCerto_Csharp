namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de administrador
    /// Consolidado - sem intermediário Usuario
    /// </summary>
    public class AdminRespostaDto
    {
        /// <summary>ID do admin</summary>
        public Guid Id { get; set; }

        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Telefone</summary>
        public string? Telefone { get; set; }

        /// <summary>Tipo de usuário (implícito: Admin)</summary>
        public int Tipo { get; set; }

        /// <summary>Nível de acesso: 1=SuperAdmin, 2=Admin (padrão), 3=Moderador</summary>
        public int NivelAcesso { get; set; }

        /// <summary>Permissões customizadas (JSON ou string delimitada)</summary>
        public string? Permissoes { get; set; }

        /// <summary>Última vez que fez login</summary>
        public DateTime? UltimoLogin { get; set; }

        /// <summary>Se admin está ativo</summary>
        public bool Ativo { get; set; }

        /// <summary>Data de criação</summary>
        public DateTime DataCriacao { get; set; }
    }
}
