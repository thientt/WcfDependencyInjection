using System;
using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Data.Core.Infrastructure;

namespace WCF.DependencyInjection.Launcher
{
    public class ClientInjectionClass : Disposable
    {
        public ClientInjectionClass(IArticleService articleService, IBlogService blogService)
        {
            ArticleProxy = articleService;
            BlogProxy = blogService;
        }

        public IBlogService BlogProxy { get; private set; }
        public IArticleService ArticleProxy { get; private set; }

        public Article[] GetArticles()
        {
            return ArticleProxy.GetAll();
        }

        public Blog[] GetBlogs()
        {
            return BlogProxy.GetAll();
        }

        public Blog GetBlogById(int id)
        {
            return BlogProxy.GetById(id);
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
                var blogClient = BlogProxy as BlogClient;
                blogClient?.CleanUp();
            }
            catch (Exception)
            {
                ArticleProxy = null;
                BlogProxy = null;
            }
        }
    }
}