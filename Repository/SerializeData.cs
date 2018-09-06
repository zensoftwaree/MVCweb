using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Entity;

namespace Repository
{
    public static class SerializeData
    {
        static string cat = @"D:\HostingSpaces\bozhuby\bo-zhu.by\data\";
        static public void ToSerialize(object graf, string fileName = "binary.dat")
        {
            Stream serializStream = File.Create(cat + fileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(serializStream, graf);
            serializStream.Close();
        }
        static public IEnumerable<ArtWorkEntity> DeSerializeArtWork(string fileName = "binary.dat")
        {
            if (File.Exists(cat + fileName))
            {
                Stream serializStream = File.OpenRead(cat + fileName);
                BinaryFormatter deserializer = new BinaryFormatter();

                IEnumerable<ArtWorkEntity> obj = deserializer.Deserialize(serializStream) as List<ArtWorkEntity>;
                serializStream.Close();
                return obj;
            }
            return null;
        }
        static public IEnumerable<Article> DeSerializeArticle(string fileName)
        {
            if (File.Exists(cat + fileName))
            {
                Stream serializStream = File.OpenRead(cat + fileName);
                BinaryFormatter deserializer = new BinaryFormatter();

                IEnumerable<Article> obj = deserializer.Deserialize(serializStream) as List<Article>;
                serializStream.Close();
                return obj;
            }
            return null;
        }
    }
}
