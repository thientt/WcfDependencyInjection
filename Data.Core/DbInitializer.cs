using System.Data.Entity;
using Business.Entities;

namespace Data.Core
{
    public class DbInitializer : CreateDatabaseIfNotExists<DIContext>
    {
        protected override void Seed(DIContext context)
        {
            base.Seed(context);

            context.BlogSet.Add(new Blog
            {
                Name = "chsakell's blog",
                Url = "http://chsakell.com",
                Owner = "Christos Sakellarios"
            });

            context.ArticleSet.Add(new Article
            {
                Title = "WCF Dependency Injection",
                Contents = "Dependency injection is a software design pattern that implements..",
                Author = "Christos Sakellarios",
                Url = "https://chsakell.com/2015/07/03/dependency-injection-in-wcf/",
                BlogId = 1
            });

            context.SaveChanges();
        }
    }
}