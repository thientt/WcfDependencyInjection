using System.Linq;
using Business.Entities;
using Data.Core.Infrastructure;

namespace Data.Core.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Article GetArticleByTitle(string title)
        {
            return DbContext.ArticleSet.FirstOrDefault(x => x.Title.Contains(title));
        }

        public int GetKeyId()
        {
            return DbContext.ArticleSet.Max(x => x.Id) + 1;
        }
    }
}