using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace Entity
{
    [Serializable()]
    public class ArtWorkEntity
    {
        private Guid id;
        
        public Guid Id
        {
            get
            {
                return id;
            }
        }
        
        public List<OneImage> images { get; set;}
        public string category { get; set;}
        public string description { get; set;}

        public ArtWorkEntity()
        {
            
            id = Guid.NewGuid();
        }
    }
}
