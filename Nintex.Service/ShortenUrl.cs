using Nintex.Data;
using Nintex.Entities;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;

namespace Nintex.Service
{
    /// <summary>
    /// This class will shorten the URL from its original form.
    /// </summary>
    public class ShortenUrl : BaseClass
    {
        private TinyUrlContext _tinyUrlContext;
        public ShortenUrl()
        {
            _tinyUrlContext = DatabaseConnection();

        }
        public TinyUrl shortenIt(string longUrl, string segment = "")
        {
            TinyUrl url = _tinyUrlContext.TinyUrls.Where(b => b.LongUrl == longUrl).FirstOrDefault();
            if (url != null)
            {
                return url;
            }
            if (!longUrl.StartsWith("http://") && !longUrl.StartsWith("https://"))
            {
                logger.Error("Invalid URL format");
            }
            Uri urlCheck = new Uri(longUrl);
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
            if (!string.IsNullOrEmpty(segment))
            {
                if (Convert.ToBoolean(_tinyUrlContext.TinyUrls.Find(segment)))
                {
                    logger.Error("Segment conflict");
                }
                if (segment.Length > 20 || !Regex.IsMatch(segment, @"^[A-Za-z\d_-]+$"))
                {
                    logger.Error("Malformed or too long segment");
                }
            }
            else
            {
                segment = this.NewSegment();
            }
            if (string.IsNullOrEmpty(segment))
            {
                logger.Error("Segment is empty");
            }

            url = new TinyUrl()
            {
                LongUrl = longUrl,
                Segment = segment
            };
            _tinyUrlContext.TinyUrls.Add(url);
            _tinyUrlContext.SaveChanges();
            _tinyUrlContext.Database.CurrentTransaction.Commit();
            return url;
        }
        private string NewSegment()
        {
            //check newly created Segment for few times in the DB
            int i = 0;
            while (true)
            {
                string newSegment = Guid.NewGuid().ToString().Substring(0, 6);
                var segmentResultFromDb = _tinyUrlContext.TinyUrls.Where(b => b.Segment == newSegment).FirstOrDefault();
                if (segmentResultFromDb == null)
                {
                    return newSegment;
                }
                if (i > 30)
                {
                    break;
                }
                i++;
            }
            return string.Empty;
        }
    }
}
