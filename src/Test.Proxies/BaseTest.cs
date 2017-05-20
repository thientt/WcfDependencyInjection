using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Business.Services;
using NUnit.Framework;
using Autofac.Integration.Wcf;
using Business.Services.Contracts;

namespace Test.Proxies
{
    [TestFixture]
    public class BaseTest
    {
        protected IContainer container = null;
        protected ServiceHost svcArticleHost = null;
        protected ServiceHost svcBlogHost = null;
        readonly Uri svcArticleServiceURI = new Uri("http://localhost:58806/ArticleService");
        readonly Uri svcBlogServiceURI = new Uri("http://localhost:58806/BlogService");

        [SetUp]
        public void Setup()
        {
            try
            {
                container = Bootstrapper.BuildContainer();
                svcArticleHost = new ServiceHost(typeof(ArticleService), svcArticleServiceURI);
                svcBlogHost = new ServiceHost(typeof(BlogService), svcBlogServiceURI);

                svcArticleHost.AddDependencyInjectionBehavior<IArticleService>(container);
                svcBlogHost.AddDependencyInjectionBehavior<IBlogService>(container);

                //Note: must run Visual Studio in Administrator mode
                svcArticleHost.Open();
                svcBlogHost.Open();
            }
            catch (Exception ex)
            {
                svcArticleHost = null;
                svcBlogHost = null;
                Console.WriteLine(ex.Message);
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (svcArticleHost != null && svcArticleHost.State != CommunicationState.Closed)
                    svcArticleHost.Close();

                if (svcBlogHost != null && svcBlogHost.State != CommunicationState.Closed)
                    svcBlogHost.Close();
            }
            finally
            {
                svcArticleHost = null;
                svcBlogHost = null;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
