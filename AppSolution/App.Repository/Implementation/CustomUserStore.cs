using App.Identity.Model;
using App.Repository.Contexto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace App.Repository.Implementation
{
    public class CustomUserStore<TEntity, TKey> : IUserStore<TEntity, TKey>, IUserPasswordStore<TEntity, TKey>, IUserSecurityStampStore<TEntity, TKey>
           where TEntity : class, IUser<TKey>
    {
        private AppContext _context = null;

        public CustomUserStore(AppContext contexto)
        {
            _context = contexto;
        }

        public Task CreateAsync(TEntity user)
        {
            _context.Set<TEntity>().Add(user);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity user)
        {
            _context.Set<TEntity>().Remove(user);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<TEntity> FindByIdAsync(TKey userId)
        {
            return _context.Set<TEntity>().FindAsync(userId);
        }

        public Task<TEntity> FindByNameAsync(string userName)
        {
            return _context.Set<TEntity>()
                .Where(u => u.UserName.ToLower() == userName.ToLower())
                .FirstOrDefaultAsync();
        }

        public Task<string> GetPasswordHashAsync(TEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var type = user.GetType();
            PropertyInfo prop = type.GetProperty("PasswordHash");
            return Task.FromResult(prop.GetValue(user).ToString());
        }

        public Task<string> GetSecurityStampAsync(TEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var type = user.GetType();
            PropertyInfo prop = type.GetProperty("SecurityStamp");
            return Task.FromResult(prop.GetValue(user).ToString());
        }

        public Task<bool> HasPasswordAsync(TEntity user)
        {
            var type = user.GetType();
            PropertyInfo prop = type.GetProperty("PasswordHash");
            return Task.FromResult(prop.GetValue(user).ToString() != null);
        }

        public Task SetPasswordHashAsync(TEntity user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var type = user.GetType();
            PropertyInfo prop = type.GetProperty("PasswordHash");
            string value = prop.GetValue(user).ToString();
            value = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetSecurityStampAsync(TEntity user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var type = user.GetType();
            PropertyInfo prop = type.GetProperty("SecurityStamp");
            string value = prop.GetValue(user).ToString();
            value = stamp;

            return Task.FromResult(0);
        }

        public Task UpdateAsync(TEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Set<TEntity>().Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        private IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim> ToIdentiyUser(AppUser user)
        {
            return new IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName
            };
        }
    }
}
