using System;
using App.Repository.Contexto;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace App.Repository.Implementation
{
    public class UsuarioRepository<TEntity, TKey> : IUserStore<TEntity, TKey>, IUserPasswordStore<TEntity, TKey>, IUserSecurityStampStore<TEntity, TKey> 
        where TEntity : class, IUser<TKey>
    {
        private AppContext _context = null;

        public UsuarioRepository(AppContext contexto)
        {
            _context = contexto;
        }

        public Task CreateAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(TKey userId)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(TEntity user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(TEntity user, string stamp)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
