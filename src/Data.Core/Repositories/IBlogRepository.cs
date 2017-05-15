using Business.Entities;

namespace Data.Core.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog GetBlogByName(string blogName);
        int GetKeyId();
    }
}