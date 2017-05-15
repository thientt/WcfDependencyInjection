using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;

namespace Business.Services
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        //private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
            : base(unitOfWork, articleRepository)
        {
            _articleRepository = articleRepository;
        }

        //public void Add(Article article)
        //{
        //    _articleRepository.Add(article);
        //    _unitOfWork.Commit();
        //}

        //public void Delete(Article article)
        //{
        //    _articleRepository.Delete(article);
        //    _unitOfWork.Commit();
        //}

        //public Article[] GetAll()
        //{
        //    return _articleRepository.GetAll().ToArray();
        //}

        //public Article GetById(int id)
        //{
        //    return _articleRepository.GetById(id);
        //}

        //public void Update(Article article)
        //{
        //    _articleRepository.Update(article);
        //    _unitOfWork.Commit();
        //}

        public int GetKeyId()
        {
            return _articleRepository.GetKeyId();
        }
    }
}