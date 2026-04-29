namespace Pc.WebApi.DTOs
{
    public class LojaCriarDto
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Descricao { get; set; }

        public Guid? EnderecoId { get; set; }
        public Guid? LojistaId { get; set; }
    }
}