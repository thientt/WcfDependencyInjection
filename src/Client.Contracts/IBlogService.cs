using System.ServiceModel;
using Client.Entities;
using Core.Utilities;

namespace Client.Contracts
{
    [ServiceContract(Namespace = Proxy.Namespace)]
    public interface IBlogService
    {
        [OperationContract]
        void Add(Blog entity);

        [OperationContract]
        void Update(Blog article);

        [OperationContract]
        void Delete(Blog article);

        [OperationContract]
        Blog GetById(int id);

        [OperationContract]
        Blog[] GetAll();

        [OperationContract]
        int GetKeyId();
    }
}