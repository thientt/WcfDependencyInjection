/*
Ref: https://github.com/chsakell/wcfdependencyinjection/blob/master/Data.Core/Infrastructure/RepositoryBase.cs
 */

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.Core.Infrastructure;

namespace Data.Core.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }

        #region Properties

        private DIContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        protected IDbFactory DbFactory { get; }

        protected DIContext DbContext => _dbContext ?? (_dbContext = DbFactory.Init());

        #endregion

        #region Implementation
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var entities = _dbSet.Where(where);
            foreach (var item in entities)
            {
                _dbSet.Remove(item);
            }
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public int GetKeyId(Func<int> func)
        {
            return func();
        }

        #endregion
    }
}