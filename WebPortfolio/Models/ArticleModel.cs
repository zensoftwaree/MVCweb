using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPortfolio.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public OneImageModel Image1 { get; set; }
    }
}