namespace Data.Core.Repositories
{
    public interface IRepository<TEntity> : IAdd<TEntity>, IUpdate<TEntity>, IDelete<TEntity>, IGet<TEntity>
        where TEntity : class
    {
    }
}