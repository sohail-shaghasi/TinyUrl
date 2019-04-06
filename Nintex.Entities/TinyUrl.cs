using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintex.Entities
{
    /// <summary>
    /// This class is an entity class, used throughout the application.
    /// </summary>
    public class TinyUrl
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string LongUrl { get; set; }
        [StringLength(100)]
        public string ShortUrl { get; set; }
        [StringLength(100)]
        public string Segment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
