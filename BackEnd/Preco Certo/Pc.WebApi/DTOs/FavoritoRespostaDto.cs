namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de favorito
    /// Retorna informações do favorito com dados relacionados (produto/loja)
    /// </summary>
    public class FavoritoRespostaDto
    {
        /// <summary>ID do favorito</summary>
        public Guid Id { get; set; }

        /// <summary>ID do cliente proprietário do favorito</summary>
        public Guid ClienteId { get; set; }

        /// <summary>ID do produto (se aplicável)</summary>
        public Guid? ProdutoId { get; set; }

        /// <summary>Nome do produto (se favorito vinculado a produto)</summary>
        public string? NomeProduto { get; set; }

        /// <summary>ID da loja (se aplicável)</summary>
        public Guid? LojaId { get; set; }

        /// <summary>Nome da loja (se favorito vinculado a loja)</summary>
        public string? NomeLoja { get; set; }

        /// <summary>Data de criação do favorito</summary>
        public DateTime DataCriacao { get; set; }
    }
}
