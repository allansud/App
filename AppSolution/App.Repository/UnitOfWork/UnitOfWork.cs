using App.Repository.Interface;
using App.Repository.Contexto;
using App.Repository.Implementation;

namespace App.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppContext _context = null;
        private UsuarioRepository _usuarioRepository = null;

        public UnitOfWork(AppContext contexto)
        {
            _context = contexto;
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepository ?? (_usuarioRepository = new UsuarioRepository(_context));
            }
        }

        public void Dispose()
        {
            _usuarioRepository = null;
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
