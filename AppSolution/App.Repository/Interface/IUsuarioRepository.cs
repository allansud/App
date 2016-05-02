using App.Domain.Entities;
using System;

namespace App.Repository.Interface
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>, IDisposable
    {
        void DesativarLock(string id);
    }
}
