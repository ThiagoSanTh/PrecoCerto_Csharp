namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de avaliação
    /// Retorna dados de avaliações de lojas
    /// </summary>
    public class AvaliacaoRespostaDto
    {
        /// <summary>ID da avaliação</summary>
        public Guid Id { get; set; }

        /// <summary>ID do cliente que fez a avaliação</summary>
        public Guid ClienteId { get; set; }

        /// <summary>ID da loja avaliada</summary>
        public Guid LojaId { get; set; }

        /// <summary>Nome da loja avaliada</summary>
        public string NomeLoja { get; set; } = string.Empty;

        /// <summary>Nota dada à loja</summary>
        public int Nota { get; set; }

        /// <summary>Comentário da avaliação</summary>
        public string? Comentario { get; set; }

        /// <summary>Data da avaliação</summary>
        public DateTime DataAvaliacao { get; set; }
    }
}
