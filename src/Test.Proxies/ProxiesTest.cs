using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Autofac;
using Client.Contracts;
using Client.Entities;
using Client.Proxies;
using Core.Common;
using Data.Core.Repositories;
using Faker;
using Moq;
using NUnit.Framework;

namespace Test.Proxies
{
    [TestFixture]
    public class ProxiesTest : BaseTest
    {
        [Test]
        public void test_self_host_connection()
        {
            Assert.That(svcArticleHost.State, Is.EqualTo(CommunicationState.Opened));
            Assert.That(svcBlogHost.State, Is.EqualTo(CommunicationState.Opened));
        }

        [Test]
        public void test_article_proxy_is_injected()
        {
            using (var lifetime = container.BeginLifetimeScope())
            {
                var proxy = container.Resolve<IArticleService>();
                Assert.IsTrue(proxy is ArticleClient);
            }
        }

        [Test]
        public void test_blog_proxy_is_injected()
        {
            using (var lifetime = container.BeginLifetimeScope())
            {
                var proxy
                    = container.Resolve<IBlogService>();

                Assert.IsTrue(proxy is BlogClient);
            }
        }

        [Test]
        public void test_article_proxy_state()
        {
            using (var lifetime = container.BeginLifetimeScope())
            {
                var proxy = container.Resolve<IArticleService>();

                var state = (proxy as ArticleClient)?.State;
                Assert.That(state, Is.EqualTo(CommunicationState.Created));

                // Open connection
                (proxy as ArticleClient)?.Open();
                Assert.That((proxy as ArticleClient)?.State, Is.EqualTo(CommunicationState.Opened));
                // Close connection
                (proxy as ArticleClient)?.Close();
                Assert.That((proxy as ArticleClient)?.State, Is.EqualTo(CommunicationState.Closed));
            }
        }

        [Test]
        public void test_article_proxy_getall()
        {
            IArticleService proxy;
            Article[] articles;

            using (var lifetime = container.BeginLifetimeScope())
            {
                proxy = container.Resolve<IArticleService>();

                var _repository = new Mock<IArticleRepository>(container.Resolve<ArticleRepository>());

                _repository.Setup(x => x.GetAll()).Returns(new List<Business.Entities.Article>
                {
                    new Business.Entities.Article
                    {
                        Id = 1,
                        BlogId = 1,
                        Author = NameFaker.Name(),
                        Contents = TextFaker.Sentence(),
                        Title = StringFaker.Alpha(20),
                        Url = InternetFaker.Url()
                    }
                });

                articles = proxy.GetAll();
            }
            Assert.That(articles.Count(), Is.EqualTo(1));

            //close connection
            if ((proxy as ArticleClient)?.State == CommunicationState.Opened)
                (proxy as ClientBase<IArticleService>).Close();
        }

        [Test]
        public void test_constructor_injected_proxy()
        {
            ClientInjectionClass _testClass = null;

            using (var lifetime = container.BeginLifetimeScope())
            {
                using (_testClass = new ClientInjectionClass(container.Resolve<IArticleService>(),
                    container.Resolve<IBlogService>()))
                {
                    {
                        var _articles = _testClass.GetArticles();
                        var _blog = _testClass.GetBlogById(1);

                        Assert.That(_articles.Count(), Is.EqualTo(1));
                        Assert.That(_blog, Is.Not.Null);
                        Assert.That(_blog.IsValid, Is.EqualTo(true));
                    }
                }
            }

            Assert.That((_testClass._articleProxy as ArticleClient)?.State, Is.EqualTo(CommunicationState.Closed));
            Assert.That((_testClass._blogProxy as BlogClient)?.State, Is.EqualTo(CommunicationState.Closed));
        }

        [Test]
        public void test_article_extension_data_not_empty()
        {
            Article[] articles = null;

            using (var lifetime = container.BeginLifetimeScope())
            {
                var proxy = container.Resolve<IArticleService>();

                articles = proxy.GetAll();
            }

            Assert.That(articles.Count(), Is.EqualTo(1));

            var contentLength = Extensions.GetExtensionDataMemberValue(articles.First(), "ContentLength");

            Assert.That(articles.First().Contents.Length, Is.EqualTo(Int32.Parse(contentLength.ToString())));
        }
    }
}