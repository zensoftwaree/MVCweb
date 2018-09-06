using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPortfolio.Models
{
    public class ArtWorkModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public List<OneImageModel> Images { get; set; }
    }
}