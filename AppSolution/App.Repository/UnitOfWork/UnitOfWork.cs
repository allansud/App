using App.Repository.Interface;
using App.Repository.Contexto;
using App.Repository.Implementation;
using App.Identity.Model;

namespace App.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppContext _context = null;
        private CustomUserStore<AppUser, int> _customUserStore = null;

        public UnitOfWork(AppContext contexto)
        {
            _context = contexto;
        }

        public CustomUserStore<AppUser, int> CustomUserStore
        {
            get
            {
                return CustomUserStore ?? (_customUserStore = new CustomUserStore<AppUser, int>(_context));
            }
        }

        public void Dispose()
        {
            _customUserStore = null;
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
