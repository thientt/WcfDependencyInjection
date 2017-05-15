using System.ServiceModel;
using Client.Entities;
using Core.Utilities;

namespace Client.Contracts
{
    [ServiceContract(Namespace = Proxy.Namespace)]
    public interface IArticleService // : IServiceBase<Article>
    {
        [OperationContract]
        void Add(Article entity);

        [OperationContract]
        void Update(Article article);

        [OperationContract]
        void Delete(Article article);

        [OperationContract]
        Article GetById(int id);

        [OperationContract]
        Article[] GetAll();

        [OperationContract]
        int GetKeyId();
    }
}