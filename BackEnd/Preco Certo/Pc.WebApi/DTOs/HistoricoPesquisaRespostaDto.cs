namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para resposta de histórico de pesquisa
    /// Retorna os registros de buscas realizadas pelo cliente
    /// </summary>
    public class HistoricoPesquisaRespostaDto
    {
        /// <summary>ID do registro de histórico</summary>
        public Guid Id { get; set; }

        /// <summary>ID do cliente</summary>
        public Guid ClienteId { get; set; }

        /// <summary>Termo que foi pesquisado</summary>
        public string TermoPesquisa { get; set; } = string.Empty;

        /// <summary>Data e hora da pesquisa</summary>
        public DateTime DataPesquisa { get; set; }
    }
}
