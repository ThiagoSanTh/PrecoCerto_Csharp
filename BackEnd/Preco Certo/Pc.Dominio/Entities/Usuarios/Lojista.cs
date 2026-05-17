using Pc.Dominio.Entities.Base;
using Pc.Dominio.Entities.Estabelecimentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pc.Dominio.Entities.Usuarios
{
    public class Lojista : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public Guid LojaId { get; set; }
        public Loja? Loja { get; set; }
        public string? Cargo { get; set; }

    }
}
