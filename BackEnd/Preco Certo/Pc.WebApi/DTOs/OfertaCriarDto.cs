using Pc.Dominio.Entities.Catalogo;
using Pc.Dominio.Entities.Estabelecimentos;

namespace Pc.WebApi.DTOs
{
    public class OfertaCriarDto
    {
        public decimal Preco { get; set; }
        public decimal? PrecoAnterior { get; set; }
        public bool EmPromocao { get; set; } = false;
        public DateTime? DataInicioPromocao { get; set; }
        public DateTime? DataFimPromocao { get; set; }
        public bool Disponivel { get; set; } = true;
        public int? QuantidadeEstoque { get; set; }
        public Guid ProdutoId { get; internal set; }
        public Guid LojaId { get; internal set; }
    }
}
