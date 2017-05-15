using System;
using System.ServiceModel;
using Client.Contracts;
using Client.Entities;

namespace Client.Proxies
{
    public class BlogClient : ClientBase<IBlogService>, IBlogService
    {
        public void Add(Blog entity)
        {
            Channel.Add(entity);
        }

        public void Delete(Blog entity)
        {
            Channel.Delete(entity);
        }

        public Blog[] GetAll()
        {
            return Channel.GetAll();
        }

        public Blog GetById(int id)
        {
            return Channel.GetById(id);
        }

        public int GetKeyId()
        {
            return Channel.GetKeyId();
        }

        public void Update(Blog entity)
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