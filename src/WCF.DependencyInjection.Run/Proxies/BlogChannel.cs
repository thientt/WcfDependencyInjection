
using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Data.Core.Infrastructure;

namespace WCF.DependencyInjection.Launcher.Channel
{
    public class BlogChannel : Disposable, IChannel
    {
        private IBlogService _blogService;

        public BlogChannel(IBlogService blogService)
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
