using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pc.Dominio.Entities.Usuarios;

namespace Pc.Repositorio.Interfaces
{
    /// <summary>
    /// Interface para operações de repositório de Usuario
    /// Herda do IRepositorio genérico e adiciona métodos específicos
    /// </summary>
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        /// <summary>
        /// Obtém usuário por email
        /// </summary>
        Task<Usuario?> ObterPorEmailAsync(string email);

        /// <summary>
        /// Obtém usuário por nome de usuário
        /// </summary>
        Task<Usuario?> ObterPorNomeUsuarioAsync(string nomeUsuario);

        /// <summary>
        /// Verifica se email já existe
        /// </summary>
        Task<bool> EmailExisteAsync(string email);

        /// <summary>
        /// Busca usuários por tipo (Cliente/Lojista)
        /// </summary>
        Task<List<Usuario>> BuscarPorTipoAsync(int tipo);
    }
}
