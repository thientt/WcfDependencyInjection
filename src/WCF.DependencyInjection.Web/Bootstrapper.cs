using Autofac;
using Business.Services;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;

namespace WCF.DependencyInjection.Web
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register services
            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            // register repositories and UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();

            return builder.Build();
        }
    }
}