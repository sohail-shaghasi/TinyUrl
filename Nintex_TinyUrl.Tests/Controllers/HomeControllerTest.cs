using System;
using System.Net.Http;
using System.Web.Mvc;
using Nintex_TinyUrl.Controllers;
using Nintex_TinyUrl.Models;
using NUnit.Framework;

namespace Nintex_TinyUrl.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Test_Index()
        {
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        [Category("Integration")]
        public void Test_RedirectShortUrlToLongLongUrl()
        {
            // Arrange
            string segment = "2e7358";
            HomeController controller = new HomeController();
            // Act
            controller.RedirectShortUrlToLongLongUrl(segment);
        }

        [Test]
        public void Test_InflateUrl()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.InflateUrl() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
