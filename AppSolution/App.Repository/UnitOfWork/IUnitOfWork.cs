using App.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.UnitOfWork
{
    /// <summary>
    /// Represents a transactional job.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Retorna repositório usuário.
        /// </summary>
        IUsuarioRepository UsuarioRepository { get; }

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        int SaveChanges();
    }
}
