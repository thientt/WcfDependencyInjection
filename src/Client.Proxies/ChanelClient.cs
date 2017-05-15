using Client.Contracts;
using System.ServiceModel;

namespace Client.Proxies
{
    public class ChanelClient<TEntity> : ClientBase<IServiceBase<TEntity>>, IServiceBase<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            Channel.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Channel.Delete(entity);
        }

        public TEntity[] GetAll()
        {
            return Channel.GetAll();
        }

        public TEntity GetById(int id)
        {
            return Channel.GetById(id);
        }

        public int GetKeyId()
        {
            return Channel.GetKeyId();
        }

        public void Update(TEntity entity)
        {
            Channel.Update(entity);
        }

        public void CleanUp()
        {
            try
            {
                if (base.State == CommunicationState.Faulted)
                    base.Close();
                else base.Abort();
            }
            catch (System.Exception)
            {
                base.Abort();
            }
        }
    }
}
