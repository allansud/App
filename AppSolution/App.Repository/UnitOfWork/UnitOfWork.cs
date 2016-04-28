using App.Repository.Interface;
using App.Repository.Contexto;
using App.Repository.Implementation;

namespace App.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppContext _context = null;
        private IDbContextFactory _factory = null;
        private UsuarioRepository _usuarioRepository = null;

        public UnitOfWork() { }

        public UnitOfWork(IDbContextFactory factory)
        {
            _factory = factory;
            _context = _factory.Create<AppContext>("AppConnect");
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
            _factory.Release<AppContext>();
            _factory = null;
            _usuarioRepository = null;
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
