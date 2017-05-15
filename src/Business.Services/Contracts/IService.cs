using System.ServiceModel;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IService<TEntity> where TEntity : class
    {
        [OperationContract]
        void Add(TEntity entity);

        [OperationContract]
        void Update(TEntity entity);

        [OperationContract]
        void Delete(TEntity entity);

        [OperationContract]
        TEntity GetById(int id);

        [OperationContract]
        TEntity[] GetAll();

        [OperationContract]
        int GetKeyId();
    }
}