using System;
using App.Domain.Entities;
using App.Repository.Contexto;
using App.Repository.Interface;

namespace App.Repository.Implementation
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppContext contexto)
            : base(contexto) { }

        public void DesativarLock(string id)
        {
            Set.Find(id).LockoutEnabled = false;
        }
    }
}
