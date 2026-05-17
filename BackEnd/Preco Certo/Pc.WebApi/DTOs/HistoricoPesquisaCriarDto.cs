namespace Pc.WebApi.DTOs
{
    /// <summary>
    /// DTO para criar um registro de histórico de pesquisa
    /// Rastreia os termos de busca do cliente para análise e recomendações
    /// </summary>
    public class HistoricoPesquisaCriarDto
    {
        /// <summary>ID do cliente que realizou a pesquisa</summary>
        public Guid ClienteId { get; set; }

        /// <summary>Termo pesquisado pelo cliente</summary>
        public string TermoPesquisa { get; set; } = string.Empty;
    }
}
