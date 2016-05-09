using App.Identity.Model;
using App.Repository.Implementation;
using System;

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
        CustomUserStore<AppUser, int> CustomUserStore { get; }

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        int SaveChanges();
    }
}
