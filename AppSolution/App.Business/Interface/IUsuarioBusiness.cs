using App.Domain.Entities;
using System.Linq;

namespace App.Business.Interface
{
    public interface IUsuarioBusiness
    {
        void Add(Usuario usuario);
        Usuario GetById(string id);
        IQueryable<Usuario> GetAll();
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
    }
}
