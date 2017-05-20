using System;
using Autofac;
using WCF.DependencyInjection.Launcher.Proxies;
using Faker;

namespace WCF.DependencyInjection.Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Register IoC
            var builder = Bootstrapper.BuildContainer();
            var blogChannel = builder.Resolve<BlogProxy>();
            for (var i = 1; i < 1000; i++)
            {
                AddBlog(blogChannel, i);
            }

            Console.Read();
        }

        private static void AddBlog(BlogProxy channel, int id)
        {
            channel.Add(new Client.Entities.Blog
            {
                Url = InternetFaker.Url(),
                Id = id,
                Name = NameFaker.Name(),
                Owner = NameFaker.Name()
            });
        }
    }
}