using System;
using System.Linq.Expressions;

namespace Data.Core.Repositories
{
    public interface IDelete<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
    }
}