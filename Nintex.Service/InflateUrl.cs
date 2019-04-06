using Nintex.Data;
using Nintex.Entities;
using System;
using System.Linq;
using System.Net;

namespace Nintex.Service
{
    /// <summary>
    /// This class will inflate the shortened URL to its original form.
    /// </summary>
    public class InflateUrl : BaseClass
    {
        private TinyUrlContext _tinyUrlContext;
        public InflateUrl()
        {
            _tinyUrlContext = DatabaseConnection();
        }
        public TinyUrl inflateUrl(string segment = "")
        {
            return _tinyUrlContext.TinyUrls.Where(u => u.Segment == segment).FirstOrDefault();
        }
        public TinyUrl GetShortUrlToLongUrl(string shortUrl)
        {
            Uri uriAddress = new Uri(shortUrl);
            var segment = uriAddress.Segments[1];
            if (string.IsNullOrEmpty(segment))
            {
                logger.Error("This Url does not have segment");
            }
            if (!shortUrl.StartsWith("http://") && !shortUrl.StartsWith("https://"))
            {
                logger.Error("Invalid URL format");
            }
            Uri urlCheck = new Uri(shortUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCheck);
            request.Timeout = 10000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                logger.Error("URL Not found");
            }
            var result = _tinyUrlContext.TinyUrls.Where(u => u.Segment == segment).FirstOrDefault();
            return result;
        }
    }
}
