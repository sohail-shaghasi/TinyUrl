using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Nintex_TinyUrl.Models
{
    public class UrlModel
    {
        [Url]
        public string LongURL { get; set; }

        [Url]
        public string ShortURL { get; set; }

        public string CustomSegment { get; set; }
    }
}