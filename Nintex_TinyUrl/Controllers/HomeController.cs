using Nintex.Entities;
using Nintex.Service;
using Nintex_TinyUrl.Models;
using NLog;
using System;
using System.Web.Mvc;

namespace Nintex_TinyUrl.Controllers
{
    /// <summary>
    /// This HomeController class Gets the request to shorten the URl,
    /// and expanding the shorten Url.
    /// </summary>
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ShortenUrl shortenUrl;
        public HomeController()
        {
            shortenUrl = new ShortenUrl();
        }

        [HttpGet]
        public ActionResult Index()
        {
            logger.Info("Index medthod invoked");
            return View();
        }
        [HttpPost]
        public ActionResult Index(UrlModel url)
        {
            string segment = Guid.NewGuid().ToString().Substring(0, 6);
            logger.Info("New segment : {0}", segment);
            if (ModelState.IsValid)
            {
                TinyUrl tinyUrl = shortenUrl.shortenIt(url.LongURL, url.CustomSegment);
                url.ShortURL = string.Format("{0}://{1}/{2}", Request.Url.Scheme, Request.Url.Authority, tinyUrl.Segment);
                logger.Info("Shorten Url : {0}", url.ShortURL);
            }
            return View(url);
        }
        public ActionResult RedirectShortUrlToLongLongUrl(string segment)
        {
            InflateUrl inflateUrl = new InflateUrl();
            logger.Info("Long Url : {0}", inflateUrl.inflateUrl(segment).LongUrl);
            return Redirect(inflateUrl.inflateUrl(segment).LongUrl);
        }
        public ActionResult InflateUrl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InflateUrl(UrlModel url)
        {
            if (ModelState.IsValid)
            {
                InflateUrl inflateUrl = new InflateUrl();
                TinyUrl tinyUrl = inflateUrl.GetShortUrlToLongUrl(url.ShortURL);
                url.LongURL = tinyUrl.LongUrl;
                logger.Info("LongURL : {0}", url.LongURL);
            }
            return View(url);
        }
    }
}