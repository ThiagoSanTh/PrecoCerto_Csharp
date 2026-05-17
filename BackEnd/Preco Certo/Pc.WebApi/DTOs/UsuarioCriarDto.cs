namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para registrar/criar novo usuário
    /// </summary>
    public class UsuarioCriarDto
    {
        /// <summary>Nome de usuário único</summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>Email único para login/contato</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Senha (mínimo 6 caracteres)</summary>
        public string Senha { get; set; } = string.Empty;

        /// <summary>Telefone opcional para contato</summary>
        public string? Telefone { get; set; }

        /// <summary>Tipo de usuário (Cliente=0, Lojista=1)</summary>
        public int Tipo { get; set; }
    }
}
