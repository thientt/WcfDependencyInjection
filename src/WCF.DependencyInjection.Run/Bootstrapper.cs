using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using Client.Contracts;
using Client.Proxies;
using WCF.DependencyInjection.Launcher.Proxies;

namespace WCF.DependencyInjection.Launcher
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            // register proxies
            builder.Register(c => new ChannelFactory<IArticleService>("BasicHttpBinding_IArticleService")).InstancePerLifetimeScope();
            builder.Register(c => new ChannelFactory<IBlogService>("BasicHttpBinding_IBlogService")).InstancePerLifetimeScope();

            builder.RegisterType<ArticleClient>().As<IArticleService>().UseWcfSafeRelease();
            builder.RegisterType<BlogClient>().As<IBlogService>().UseWcfSafeRelease();

            RegisterChannel(builder);

            // build container
            return builder.Build();
        }

        public static void RegisterChannel(ContainerBuilder builder)
        {
            (from item in Assembly.GetExecutingAssembly().GetTypes()
             where typeof(IProxy).IsAssignableFrom(item) &&
                   item.IsClass && item.IsPublic &&
                   !(item.FullName.StartsWith("mscorlib") || item.FullName.StartsWith("System"))
             select item).ToList().ForEach(ins => builder.RegisterType(ins));
        }
    }
}