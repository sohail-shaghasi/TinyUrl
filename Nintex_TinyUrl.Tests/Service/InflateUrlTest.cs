using Nintex.Service;
using NUnit.Framework;

namespace Nintex_TinyUrl.Tests.Service
{
    [TestFixture]
    public class InflateUrlTest
    {
        private ShortenUrl _shortenUrl;
        private InflateUrl _inflateUrl;


        [SetUp]
        public void Setup()
        {
            _shortenUrl = new ShortenUrl();
            _inflateUrl = new InflateUrl(); 
        }

        [TestCase("https://products.office.com/en-my/outlook/email-and-calendar-software-microsoft-outlook?tab=tabs-2")]
        public void Test_Inflate_Url(string longUrl)
        {
            var resultFromShortenIt = _shortenUrl.shortenIt(longUrl);
            var resultFromInflateUrl = _inflateUrl.inflateUrl(resultFromShortenIt.Segment);
            Assert.IsNotNull(resultFromInflateUrl.Segment);
        }
    }
}
