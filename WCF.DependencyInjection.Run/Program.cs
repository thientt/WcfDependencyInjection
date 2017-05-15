using System;
using Autofac;

namespace WCF.DependencyInjection.Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Register IoC
            var builder = Bootstrapper.BuildContainer();
            var client = builder.Resolve<ClientInjectionClass>();

            var articles = client.GetArticleById(1);
            Console.WriteLine(articles.Title);

            var blogs = client.GetBlogById(1);
            Console.WriteLine(blogs?.Owner);
            Console.Read();
        }
    }
}