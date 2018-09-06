using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPortfolio.Models
{
    public class ArtWorkOneSlide
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public OneImageModel Image { get; set; }
    }
}