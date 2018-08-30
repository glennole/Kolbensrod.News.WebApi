using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolbensrod.news.webapi.Models
{
    public class News
    {
        public int NewsId { get; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }
    }
}
