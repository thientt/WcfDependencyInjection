namespace Data.Core.Repositories
{
    public interface IUpdate<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }
}