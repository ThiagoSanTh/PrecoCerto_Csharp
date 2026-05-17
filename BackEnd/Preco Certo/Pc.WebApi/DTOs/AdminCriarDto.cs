namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para registrar novo administrador
    /// Consolidado - sem intermediário Usuario
    /// </summary>
    public class AdminCriarDto
    {
        /// <summary>Nome de usuário</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email (deve ser único)</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Senha (mínimo 6 caracteres)</summary>
        public string Senha { get; set; } = string.Empty;

        /// <summary>Telefone (opcional)</summary>
        public string? Telefone { get; set; }

        /// <summary>Nível de acesso: 1=SuperAdmin, 2=Admin (padrão), 3=Moderador</summary>
        public int NivelAcesso { get; set; } = 2;
    }
}
