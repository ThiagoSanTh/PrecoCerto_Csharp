using Pc.Dominio.Entities.Usuarios;

namespace Pc.Servico.Interfaces
{
    /// <summary>
    /// Interface do serviço de Usuario
    /// Define contrato para operações de negócio relacionadas a usuários
    /// Inclui autenticação, registro e gerenciamento
    /// </summary>
    public interface IUsuarioServico
    {
        /// <summary>
        /// Registra um novo usuário
        /// Valida email único e dados obrigatórios
        /// </summary>
        Task<Usuario> RegistrarAsync(Usuario usuario);

        /// <summary>
        /// Obtém usuário por ID
        /// </summary>
        Task<Usuario?> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Busca usuário por email para autenticação
        /// </summary>
        Task<Usuario?> BuscarPorEmailAsync(string email);

        /// <summary>
        /// Valida credenciais de login (email + senha)
        /// Retorna usuário se válido, null caso contrário
        /// </summary>
        Task<Usuario?> ValidarLoginAsync(string email, string senha);

        /// <summary>
        /// Atualiza dados do usuário
        /// </summary>
        Task AtualizarAsync(Usuario usuario);

        /// <summary>
        /// Altera a senha do usuário
        /// </summary>
        Task AlterarSenhaAsync(Guid usuarioId, string senhaAtual, string novaSenha);

        /// <summary>
        /// Desativa/ativa um usuário
        /// </summary>
        Task AlterarStatusAsync(Guid usuarioId, bool ativo);

        /// <summary>
        /// Remove um usuário (soft delete via Ativo)
        /// </summary>
        Task RemoverAsync(Guid id);

        /// <summary>
        /// Lista todos os usuários ativos
        /// </summary>
        Task<List<Usuario>> ListarAtivosAsync();
    }
}
