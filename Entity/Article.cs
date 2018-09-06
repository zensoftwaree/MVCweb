using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entity
{
    [Serializable()]
    public class Article
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public OneImage Image1 { get; set; }

        public Article()
        {
            Id = Guid.NewGuid();
            Image1 = new OneImage();
        }
    }
}
