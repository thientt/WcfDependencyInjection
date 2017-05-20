using System;
using System.Collections.Generic;
using System.ServiceModel;
using Autofac;
using Business.Entities;
using Business.Services;
using Business.Services.Contracts;
using Client.Proxies;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using Faker;
using Moq;

namespace Test.Proxies
{
    public static class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            //register services
            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            // register proxies
            builder.Register(
                c => new ChannelFactory<Client.Contracts.IArticleService>("BasicHttpBinding_IArticleService"))
                .InstancePerLifetimeScope();
            builder.Register(c => new ChannelFactory<Client.Contracts.IBlogService>("BasicHttpBinding_IBlogService"))
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogClient>().As<Client.Contracts.IBlogService>();
            builder.RegisterType<ArticleClient>().As<Client.Contracts.IArticleService>();

            //DbFactory
            var _dbFactory = new Mock<DbFactory>();
            builder.RegisterInstance(_dbFactory.Object).As<IDbFactory>();

            //unit of work
            var _unitOfWork = new Mock<UnitOfWork>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("dbFactory", _dbFactory.Object);
            //builder.RegisterInstance<IUnitOfWork>(_unitOfWork.Object);
            //builder.RegisterInstance(_unitOfWork.Object).As<IUnitOfWork>();

            //Repositories
            var _articleRepository = new Mock<IArticleRepository>();
            //_articleRepository.Setup(x => x.GetAll()).Returns(new List<Article>
            //{
            //    new Article
            //    {
            //        Id = 1,
            //        BlogId = 1,
            //        Author = NameFaker.Name(),
            //        Contents = TextFaker.Sentence(),
            //        Title = StringFaker.Alpha(20),
            //        Url = InternetFaker.Url()
            //    }
            //});
            builder.RegisterInstance(_articleRepository.Object).As<IArticleRepository>();

            var _blogRepository = new Mock<IBlogRepository>();
            _blogRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Blog>(id => new Blog
                {
                    Id = id,
                    Name = NameFaker.Name(),
                    Owner = NameFaker.Name(),
                    Url = InternetFaker.Url()
                }));
            builder.RegisterInstance(_blogRepository.Object).As<IBlogRepository>();

            builder.RegisterType<ClientInjectionClass>();

            return builder.Build();
        }
    }
}