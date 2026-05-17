using Microsoft.AspNetCore.Mvc;
using Pc.Dominio.Entities.Usuarios;
using Pc.Servico.Interfaces;
using Pc.WebApi.DTOs;

namespace Pc.WebApi.Controllers
{
    /// <summary>
    /// Controller para operações com Usuários
    /// Endpoints para registro, login, gerenciamento de usuários
    /// Rota base: /api/usuarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        /// <summary>
        /// Injeta o serviço de usuário
        /// </summary>
        public UsuariosController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        /// <summary>
        /// POST: /api/usuarios/registrar
        /// Registra um novo usuário no sistema
        /// Body: UsuarioCriarDto
        /// Valida: email único, senha válida, dados obrigatórios
        /// </summary>
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioCriarDto dto)
        {
            var usuario = new Usuario
            {
                NomeUsuario = dto.NomeUsuario,
                Email = dto.Email,
                SenhaHash = dto.Senha, // TODO: Hash com bcrypt
                Telefone = dto.Telefone,
                Tipo = (Pc.Dominio.Enums.TipoUsuario)dto.Tipo
            };

            var novoUsuario = await _usuarioServico.RegistrarAsync(usuario);

            var resposta = new UsuarioRespostaDto
            {
                Id = novoUsuario.Id,
                NomeUsuario = novoUsuario.NomeUsuario,
                Email = novoUsuario.Email,
                Telefone = novoUsuario.Telefone,
                Tipo = (int)novoUsuario.Tipo,
                UltimoLogin = novoUsuario.UltimoLogin,
                Ativo = novoUsuario.Ativo,
                DataCriacao = novoUsuario.DataCriacao
            };

            return CreatedAtAction(nameof(ObterPorId), new { id = resposta.Id }, resposta);
        }

        /// <summary>
        /// POST: /api/usuarios/login
        /// Valida credenciais de login
        /// Body: { "email": "user@email.com", "senha": "123456" }
        /// Retorna usuário se credenciais válidas
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] dynamic body)
        {
            var email = body?.email?.ToString();
            var senha = body?.senha?.ToString();

            var usuario = await _usuarioServico.ValidarLoginAsync(email, senha);

            if (usuario == null)
                return Unauthorized("Email ou senha incorretos.");

            var resposta = new UsuarioRespostaDto
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Tipo = (int)usuario.Tipo,
                UltimoLogin = usuario.UltimoLogin,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };

            return Ok(resposta);
        }

        /// <summary>
        /// GET: /api/usuarios/{id}
        /// Retorna um usuário específico
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var usuario = await _usuarioServico.ObterPorIdAsync(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            var resposta = new UsuarioRespostaDto
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Tipo = (int)usuario.Tipo,
                UltimoLogin = usuario.UltimoLogin,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };

            return Ok(resposta);
        }

        /// <summary>
        /// GET: /api/usuarios/email/{email}
        /// Busca usuário por email
        /// </summary>
        [HttpGet("email/{email}")]
        public async Task<IActionResult> BuscarPorEmail(string email)
        {
            var usuario = await _usuarioServico.BuscarPorEmailAsync(email);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            var resposta = new UsuarioRespostaDto
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Tipo = (int)usuario.Tipo,
                UltimoLogin = usuario.UltimoLogin,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };

            return Ok(resposta);
        }

        /// <summary>
        /// GET: /api/usuarios
        /// Lista todos os usuários ativos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _usuarioServico.ListarAtivosAsync();

            var resposta = usuarios.Select(u => new UsuarioRespostaDto
            {
                Id = u.Id,
                NomeUsuario = u.NomeUsuario,
                Email = u.Email,
                Telefone = u.Telefone,
                Tipo = (int)u.Tipo,
                UltimoLogin = u.UltimoLogin,
                Ativo = u.Ativo,
                DataCriacao = u.DataCriacao
            });

            return Ok(resposta);
        }

        /// <summary>
        /// PUT: /api/usuarios/{id}
        /// Atualiza dados do usuário
        /// Body: UsuarioCriarDto
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UsuarioCriarDto dto)
        {
            var usuario = await _usuarioServico.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            usuario.NomeUsuario = dto.NomeUsuario;
            usuario.Email = dto.Email;
            usuario.Telefone = dto.Telefone;

            await _usuarioServico.AtualizarAsync(usuario);

            var resposta = new UsuarioRespostaDto
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Tipo = (int)usuario.Tipo,
                UltimoLogin = usuario.UltimoLogin,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };

            return Ok(resposta);
        }

        /// <summary>
        /// PUT: /api/usuarios/{id}/senha
        /// Altera a senha do usuário
        /// Body: { "senhaAtual": "123456", "novaSenha": "654321" }
        /// </summary>
        [HttpPut("{id:guid}/senha")]
        public async Task<IActionResult> AlterarSenha(Guid id, [FromBody] dynamic body)
        {
            var senhaAtual = body?.senhaAtual?.ToString();
            var novaSenha = body?.novaSenha?.ToString();

            await _usuarioServico.AlterarSenhaAsync(id, senhaAtual, novaSenha);

            return Ok(new { mensagem = "Senha alterada com sucesso" });
        }

        /// <summary>
        /// DELETE: /api/usuarios/{id}
        /// Remove/desativa um usuário
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _usuarioServico.RemoverAsync(id);
            return NoContent();
        }
    }
}
