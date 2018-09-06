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
    public class OneImage
    {
        private Guid idOwn;

        public Guid IdOwn
        {
            get
            {
                return idOwn;
            }
        }
        public Guid id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        //public string Description { get; set; }

        public OneImage()
        {
            idOwn = Guid.NewGuid();
        }
    }
}
