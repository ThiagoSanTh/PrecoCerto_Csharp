using Pc.Dominio.Entities.Estabelecimentos;
using Pc.Dominio.Entities.Usuarios;

namespace Pc.WebApi.DTOs
{
    public class LojaCriarDto
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public Guid EnderecoId { get; internal set; }
        public object LojistaId { get; internal set; }
    }
}
