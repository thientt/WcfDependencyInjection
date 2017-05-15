using System.ServiceModel;
using Business.Entities;
using Core.Utilities;
using System.Collections.Generic;

namespace Business.Services.Contracts
{
    [ServiceContract(Namespace = Proxy.Namespace)]
    public interface IBlogService
    {
        [OperationContract]
        void Add(Blog entity);

        [OperationContract]
        void Update(Blog entity);

        [OperationContract]
        void Delete(Blog entity);

        [OperationContract]
        Blog GetById(int id);

        [OperationContract]
        IEnumerable<Blog> GetAll();

        [OperationContract]
        int GetKeyId();
    }
}