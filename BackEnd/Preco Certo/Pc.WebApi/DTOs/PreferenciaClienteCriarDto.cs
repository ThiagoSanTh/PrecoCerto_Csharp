namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para criar uma preferência de cliente
    /// Armazena configurações e preferências do usuário (chave-valor)
    /// </summary>
    public class PreferenciaClienteCriarDto
    {
        /// <summary>ID do cliente dono da preferência</summary>
        public Guid ClienteId { get; set; }

        /// <summary>Chave identificadora da preferência (ex: "raio_busca", "notificacoes")</summary>
        public string Chave { get; set; } = string.Empty;

        /// <summary>Valor da preferência (ex: "10km", "habilitado")</summary>
        public string Valor { get; set; } = string.Empty;
    }
}
