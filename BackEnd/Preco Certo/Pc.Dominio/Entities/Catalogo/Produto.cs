using Pc.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pc.Dominio.Entities.Catalogo
{
    public class Produto : BaseEntity
    {
        public string NomeProduto { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string? Marca { get; set; }
        public string? CodigoBarras { get; set; }
        //public Guid CategoriaId { get; set; }
        //public Categoria? Categoria { get; set; }
    }
}
