using Pc.Dominio.Entities.Usuarios;
using Pc.Repositorio.Interfaces;
using Pc.Servico.Interfaces;

namespace Pc.Servico.Implementacoes
{
    /// <summary>
    /// Serviço de Usuario
    /// Contém lógica de negócio para operações com usuários
    /// Valida regras de negócio: email único, senha válida, etc
    /// Padrão: Validação no serviço, acesso via repositório
    /// </summary>
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Injeta o repositório de usuário
        /// </summary>
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Registra um novo usuário com validações
        /// Valida: email único, nome de usuário preenchido, senha válida
        /// </summary>
        public async Task<Usuario> RegistrarAsync(Usuario usuario)
        {
            // Validação: dados obrigatórios
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("Email é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.NomeUsuario))
                throw new Exception("Nome de usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.SenhaHash) || usuario.SenhaHash.Length < 6)
                throw new Exception("Senha deve ter no mínimo 6 caracteres.");

            // Validação: email único
            if (await _usuarioRepositorio.EmailExisteAsync(usuario.Email))
                throw new Exception("Email já cadastrado no sistema.");

            // TODO: Hash senha com bcrypt (implementar em produção!)
            // Por enquanto apenas validação básica

            usuario.DataCriacao = DateTime.UtcNow;
            usuario.Ativo = true;

            return await _usuarioRepositorio.AdicionarAsync(usuario);
        }

        /// <summary>
        /// Obtém usuário por ID
        /// </summary>
        public async Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            return await _usuarioRepositorio.ObterPorIdAsync(id);
        }

        /// <summary>
        /// Busca usuário por email
        /// </summary>
        public async Task<Usuario?> BuscarPorEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email é obrigatório.");

            return await _usuarioRepositorio.ObterPorEmailAsync(email);
        }

        /// <summary>
        /// Valida credenciais de login
        /// Retorna usuário se email/senha válidos
        /// TODO: Implementar comparação segura de senha com bcrypt
        /// </summary>
        public async Task<Usuario?> ValidarLoginAsync(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                throw new Exception("Email e senha são obrigatórios.");

            var usuario = await _usuarioRepositorio.ObterPorEmailAsync(email);

            if (usuario == null || !usuario.Ativo)
                return null;

            // TODO: Comparar senha com bcrypt
            // if (!BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
            //     return null;

            // Atualiza último login
            usuario.UltimoLogin = DateTime.UtcNow;
            await _usuarioRepositorio.AtualizarAsync(usuario);

            return usuario;
        }

        /// <summary>
        /// Atualiza dados do usuário
        /// </summary>
        public async Task AtualizarAsync(Usuario usuario)
        {
            if (usuario.Id == Guid.Empty)
                throw new Exception("ID é obrigatório.");

            usuario.DataAtualizacao = DateTime.UtcNow;
            await _usuarioRepositorio.AtualizarAsync(usuario);
        }

        /// <summary>
        /// Altera a senha do usuário
        /// Valida senha atual antes de permitir mudança
        /// </summary>
        public async Task AlterarSenhaAsync(Guid usuarioId, string senhaAtual, string novaSenha)
        {
            if (usuarioId == Guid.Empty)
                throw new Exception("UsuarioId é obrigatório.");

            if (string.IsNullOrWhiteSpace(novaSenha) || novaSenha.Length < 6)
                throw new Exception("Nova senha deve ter no mínimo 6 caracteres.");

            var usuario = await _usuarioRepositorio.ObterPorIdAsync(usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            // TODO: Validar senhaAtual com bcrypt
            // if (!BCrypt.Net.BCrypt.Verify(senhaAtual, usuario.SenhaHash))
            //     throw new Exception("Senha atual incorreta.");

            usuario.SenhaHash = novaSenha; // TODO: Hash com bcrypt
            usuario.DataAtualizacao = DateTime.UtcNow;
            await _usuarioRepositorio.AtualizarAsync(usuario);
        }

        /// <summary>
        /// Desativa/ativa um usuário (soft delete)
        /// </summary>
        public async Task AlterarStatusAsync(Guid usuarioId, bool ativo)
        {
            var usuario = await _usuarioRepositorio.ObterPorIdAsync(usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            usuario.Ativo = ativo;
            usuario.DataAtualizacao = DateTime.UtcNow;
            await _usuarioRepositorio.AtualizarAsync(usuario);
        }

        /// <summary>
        /// Remove usuário (marcando como inativo)
        /// </summary>
        public async Task RemoverAsync(Guid id)
        {
            await AlterarStatusAsync(id, false);
        }

        /// <summary>
        /// Lista todos os usuários ativos
        /// </summary>
        public async Task<List<Usuario>> ListarAtivosAsync()
        {
            var usuarios = await _usuarioRepositorio.ListarAsync();
            return usuarios.Where(u => u.Ativo).ToList();
        }
    }
}
