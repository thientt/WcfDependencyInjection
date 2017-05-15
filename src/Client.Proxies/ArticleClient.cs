using System;
using System.ServiceModel;
using Client.Contracts;
using Client.Entities;

namespace Client.Proxies
{
    public class ArticleClient : ClientBase<IArticleService>, IArticleService
    {
        public void Add(Article entity)
        {
            Channel.Add(entity);
        }

        public void Delete(Article entity)
        {
            Channel.Delete(entity);
        }

        public Article[] GetAll()
        {
            return Channel.GetAll();
        }

        public Article GetById(int id)
        {
            return Channel.GetById(id);
        }

        public int GetKeyId()
        {
            return Channel.GetKeyId();
        }

        public void Update(Article entity)
        {
            Channel.Update(entity);
        }

        public void CleanUp()
        {
            try
            {
                if (State == CommunicationState.Faulted)
                    Close();
                else Abort();
            }
            catch (Exception)
            {
                Abort();
            }
        }
    }
}