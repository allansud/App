using App.Business.Interface;
using App.Domain.Entities;
using App.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Implementation
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private IUnitOfWork _unitOfWork = null;

        public UsuarioBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Insert(usuario);
            _unitOfWork.SaveChanges();
        }

        public void DesativarLock(string id)
        {
            _unitOfWork.UsuarioRepository.DesativarLock(id);
            _unitOfWork.SaveChanges();
        }

        public IQueryable<Usuario> GetAll()
        {
            var userList = _unitOfWork.UsuarioRepository.GetAll();

            return userList;
        }

        public Usuario GetById(string id)
        {
            return _unitOfWork.UsuarioRepository.Get(id);
        }

        public void Remove(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Delete(usuario);
            _unitOfWork.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Update(usuario);
            _unitOfWork.SaveChanges();
        }
    }
}
