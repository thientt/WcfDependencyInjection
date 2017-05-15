using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using Business.Services;
using Business.Services.Contracts;
using Client.Proxies;
using Data.Core.Infrastructure;

namespace WCF.DependencyInjection.Launcher
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register services
            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            // register proxies
            var channelArticle = new ChannelFactory<Client.Contracts.IArticleService>("BasicHttpBinding_IArticleService");
            builder.Register(c => channelArticle).InstancePerLifetimeScope();
            var channelBlog = new ChannelFactory<Client.Contracts.IBlogService>("BasicHttpBinding_IBlogService");
            builder.Register(c => channelBlog).InstancePerLifetimeScope();

            builder.RegisterType<ArticleClient>().As<Client.Contracts.IArticleService>().UseWcfSafeRelease();
            builder.RegisterType<BlogClient>().As<Client.Contracts.IBlogService>().UseWcfSafeRelease();

            // Unit of Work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            // DbFactory
            builder.RegisterType<DbFactory>().As<IDbFactory>();

            builder.RegisterType<ClientInjectionClass>();

            // build container
            return builder.Build();
        }
    }
}