using System;
using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Data.Core.Infrastructure;
using WCF.DependencyInjection.Launcher.Channel;

namespace WCF.DependencyInjection.Launcher
{
    public class ArticleChannel : Disposable, IChannel
    {
        public ArticleChannel(IArticleService articleService)
        {
            ArticleProxy = articleService;
        }

        public IArticleService ArticleProxy { get; private set; }

        public Article[] GetArticles()
        {
            return ArticleProxy.GetAll();
        }

        public Article GetArticleById(int id)
        {
            return ArticleProxy.GetById(id);
        }

        protected override void DisposeCore()
        {
            base.DisposeCore();

            try
            {
                var articleClient = ArticleProxy as ArticleClient;
                articleClient?.CleanUp();
            }
            finally
            {
                ArticleProxy = null;
            }
        }
    }
}