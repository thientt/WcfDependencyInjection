
using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Data.Core.Infrastructure;

namespace WCF.DependencyInjection.Launcher.Proxies
{
    public class BlogProxy : Disposable, IProxy
    {
        private IBlogService _blogService;

        public BlogProxy(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public void Add(Blog blog)
        {
            _blogService.Add(blog);
        }

        protected override void DisposeCore()
        {
            base.DisposeCore();

            try
            {
                var articleClient = _blogService as ArticleClient;
                articleClient?.CleanUp();
            }
            finally
            {
                _blogService = null;
            }
        }
    }
}
