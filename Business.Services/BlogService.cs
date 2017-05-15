using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;

namespace Business.Services
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IUnitOfWork unitOfWork, IBlogRepository blogRepository) : base(unitOfWork, blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public int GetKeyId()
        {
            return _blogRepository.GetKeyId();
        }
    }
}