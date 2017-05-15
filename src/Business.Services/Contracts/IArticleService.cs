using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;
using Core.Utilities;

namespace Business.Services.Contracts
{
    [ServiceContract(Namespace = Proxy.Namespace)]
    public interface IArticleService
    {
        [OperationContract]
        void Add(Article entity);

        [OperationContract]
        void Update(Article entity);

        [OperationContract]
        void Delete(Article entity);

        [OperationContract]
        Article GetById(int id);

        [OperationContract]
        IEnumerable<Article> GetAll();

        [OperationContract]
        int GetKeyId();
    }
}