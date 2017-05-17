using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using Client.Proxies;
using Data.Core.Infrastructure;
using WCF.DependencyInjection.Launcher.Channel;
using System.Reflection;
using System.Linq;

namespace WCF.DependencyInjection.Launcher
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            // register proxies
            var channelArticle = new ChannelFactory<Client.Contracts.IArticleService>("BasicHttpBinding_IArticleService");
            builder.Register(c => channelArticle).InstancePerLifetimeScope();
            var channelBlog = new ChannelFactory<Client.Contracts.IBlogService>("BasicHttpBinding_IBlogService");
            builder.Register(c => channelBlog).InstancePerLifetimeScope();

            builder.RegisterType<ArticleClient>().As<Client.Contracts.IArticleService>().UseWcfSafeRelease();
            builder.RegisterType<BlogClient>().As<Client.Contracts.IBlogService>().UseWcfSafeRelease();

            builder.RegisterType<ArticleChannel>();

            RegisterChannel(builder);

            // build container
            return builder.Build();
        }

        public static void RegisterChannel(ContainerBuilder builder)
        {
            var instances = (from item in Assembly.GetExecutingAssembly().GetTypes()
                             where typeof(IChannel).IsAssignableFrom(item) && item.IsClass
                             select item);

            foreach (var item in instances)
            {
                builder.RegisterType(item);
            }
        }
    }
}