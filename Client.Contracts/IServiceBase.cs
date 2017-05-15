using System.ServiceModel;
using Core.Utilities;

namespace Client.Contracts
{
    [ServiceContract(Namespace = Proxy.Namespace)]
    public interface IServiceBase<TEntity> where TEntity : class
    {
        [OperationContract]
        void Add(TEntity entity);

        [OperationContract]
        void Update(TEntity article);

        [OperationContract]
        void Delete(TEntity article);

        [OperationContract]
        TEntity GetById(int id);

        [OperationContract]
        TEntity[] GetAll();

        int GetKeyId();
    }
}