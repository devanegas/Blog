using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{

    //URL FRIENDLY LOOL AT SEO FRIENDLY URLS
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime TimePosted { get; set; }
    }
}
