using Pc.Dominio.Entities.Base;
using Pc.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pc.Dominio.Entities.Usuarios
{
    public class Usuario : BaseEntity
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public TipoUsuario Tipo { get; set; }
        public DateTime? UltimoLogin { get; set; }
    
    }
}
