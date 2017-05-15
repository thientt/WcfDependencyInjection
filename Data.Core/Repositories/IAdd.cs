namespace Data.Core.Repositories
{
    public interface IAdd<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
    }
}