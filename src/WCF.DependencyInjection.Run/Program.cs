using System;
using Autofac;
using WCF.DependencyInjection.Launcher.Channel;
using Faker;

namespace WCF.DependencyInjection.Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Register IoC
            var builder = Bootstrapper.BuildContainer();
            var blogChannel = builder.Resolve<BlogChannel>();
            AddBlog(blogChannel);

            Console.Read();
        }

        private static void AddBlog(BlogChannel channel)
        {
            channel.Add(new Client.Entities.Blog
            {
                Url = InternetFaker.Url(),
                Id = NumberFaker.Number(3, 1000),
                Name = NameFaker.Name(),
                Owner = NameFaker.Name()
            });
        }

        private static void AddBlogFail(BlogChannel channel)
        {
            channel.Add(new Client.Entities.Blog());
        }
    }
}