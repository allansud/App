using App.Repository.Contexto;
using App.Repository.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using App.Domain.Entities;

namespace App.Repository.Implementation
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private AppContext _context = null;
        private DbSet<TEntity> _set = null;

        public RepositoryBase(AppContext contexto)
        {
            _context = contexto;
        }

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        protected AppContext Context
        {
            get { return _context; }
        }

        public void Delete(TEntity obj)
        {
            Set.Remove(obj);
        }

        public void Dispose()
        {

        }

        public TEntity Get(string key)
        {
            return Set.Find(key);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Set.ToList().AsQueryable();
        }

        public void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }
    }
}
