using System.Linq;
using Business.Entities;
using Data.Core.Infrastructure;

namespace Data.Core.Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Blog GetBlogByName(string blogName)
        {
            return DbContext.BlogSet.FirstOrDefault(x => x.Name.Contains(blogName));
        }

        public int GetKeyId()
        {
            return DbContext.BlogSet.Max(x => x.Id) + 1;
        }
    }
}