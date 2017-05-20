using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Data.Core.Infrastructure;

namespace Test.Proxies
{
    public class ClientInjectionClass : Disposable
    {
        public IArticleService _articleProxy;
        public IBlogService _blogProxy;

        public ClientInjectionClass(IArticleService articleServiceProxy,
            IBlogService blogServiceProxy)
        {
            _blogProxy = blogServiceProxy;
            _articleProxy = articleServiceProxy;
        }

        #region IDisposable

        protected override void DisposeCore()
        {
            base.DisposeCore();
            try
            {
                (_blogProxy as BlogClient)?.CleanUp();

                (_articleProxy as ArticleClient)?.CleanUp();
            }
            catch
            {
                _blogProxy = null;
                _articleProxy = null;
            }
        }

        #endregion

        #region Methods

        public Article[] GetArticles()
        {
            return _articleProxy.GetAll();
        }

        public Blog GetBlogById(int id)
        {
            return _blogProxy.GetById(id);
        }

        #endregion
    }
}