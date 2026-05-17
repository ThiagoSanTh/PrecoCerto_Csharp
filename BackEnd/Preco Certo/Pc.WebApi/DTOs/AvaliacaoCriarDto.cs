namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para criar uma avaliação de loja
    /// Permite que clientes avaliem lojas e deixem comentários
    /// </summary>
    public class AvaliacaoCriarDto
    {
        /// <summary>ID do cliente que está avaliando</summary>
        public Guid ClienteId { get; set; }

        /// <summary>ID da loja sendo avaliada</summary>
        public Guid LojaId { get; set; }

        /// <summary>Nota da avaliação (1-5 ou similar)</summary>
        public int Nota { get; set; }

        /// <summary>Comentário opcional da avaliação</summary>
        public string? Comentario { get; set; }
    }
}
