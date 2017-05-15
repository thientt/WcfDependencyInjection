using Business.Entities;

namespace Data.Core.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        Article GetArticleByTitle(string title);
        int GetKeyId();
    }
}