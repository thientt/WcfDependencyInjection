using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Core.Repositories
{
    public interface IGet<TEntity> where TEntity : class
    {
        // Get an entity by int id
        TEntity GetById(int id);
        // Get an entity using delegate
        TEntity Get(Expression<Func<TEntity, bool>> where);
        // Gets all entities of type T
        IEnumerable<TEntity> GetAll();
        // Gets entities using delegate
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        int GetKeyId(Func<int> func);
    }
}