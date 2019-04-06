using Nintex.Service;
using NUnit.Framework;

namespace Nintex_TinyUrl.Tests.Service
{
    [TestFixture]
    public class ShortenUrlTest
    {
        private ShortenUrl _shortenUrl;

        [SetUp]
        public void Setup()
        {
            _shortenUrl = new ShortenUrl();
        }

        [TestCase("https://products.office.com/en-my/outlook/email-and-calendar-software-microsoft-outlook?tab=tabs-2")]
        public void Test_Shorten_Url(string longUrl)
        {
            var resultFromShortenIt = _shortenUrl.shortenIt(longUrl);
            Assert.IsNotNull(resultFromShortenIt.ShortUrl);
        }
    }
}
