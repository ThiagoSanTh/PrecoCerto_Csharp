namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para criar um novo favorito
    /// Permite que um cliente marque um produto ou loja como favorito
    /// </summary>
    public class FavoritoCriarDto
    {
        /// <summary>ID do cliente que está adicionando o favorito</summary>
        public Guid ClienteId { get; set; }

        /// <summary>ID do produto (opcional - pode favoritar apenas loja)</summary>
        public Guid? ProdutoId { get; set; }

        /// <summary>ID da loja (opcional - pode favoritar apenas produto)</summary>
        public Guid? LojaId { get; set; }
    }
}
