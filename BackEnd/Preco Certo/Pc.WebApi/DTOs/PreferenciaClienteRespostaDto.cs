namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de preferência de cliente
    /// Retorna configurações e preferências armazenadas do cliente
    /// </summary>
    public class PreferenciaClienteRespostaDto
    {
        /// <summary>ID da preferência</summary>
        public Guid Id { get; set; }

        /// <summary>ID do cliente proprietário</summary>
        public Guid ClienteId { get; set; }

        /// <summary>Chave identificadora da preferência</summary>
        public string Chave { get; set; } = string.Empty;

        /// <summary>Valor da preferência</summary>
        public string Valor { get; set; } = string.Empty;

        /// <summary>Data de criação da preferência</summary>
        public DateTime DataCriacao { get; set; }
    }
}
