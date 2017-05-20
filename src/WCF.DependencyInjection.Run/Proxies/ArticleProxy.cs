using System;
using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Data.Core.Infrastructure;

namespace WCF.DependencyInjection.Launcher.Proxies
{
    public class ArticleProxy : Disposable, IProxy
    {
        public ArticleProxy(IArticleService articleService)
        {
            _articleProxy = articleService;
        }

        private readonly IArticleService _articleProxy;

        public Article[] GetArticles()
        {
            return _articleProxy.GetAll();
        }

        public Article GetArticleById(int id)
        {
            return _articleProxy.GetById(id);
        }

        protected override void DisposeCore()
        {
            base.DisposeCore();

            try
            {
                var articleClient = _articleProxy as ArticleClient;
                articleClient?.CleanUp();
            }
            finally
            {
            }
        }
    }
}