using System.Threading.Tasks;

namespace Data.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        int Push();
        Task<int> PushAsync();
    }
}