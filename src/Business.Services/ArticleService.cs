using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;

namespace Business.Services
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
            : base(unitOfWork, articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public int GetKeyId()
        {
            return _articleRepository.GetKeyId();
        }
    }
}