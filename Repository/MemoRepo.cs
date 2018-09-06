using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public class MemoRepo : IWorkWithRepo
    {
        private static List<ArtWorkEntity> mainCollect;
        static MemoRepo()
        {
            mainCollect = new List<ArtWorkEntity>();

            try
            {
                mainCollect = SerializeData.DeSerializeArtWork().ToList();
            }
            catch { }
        }

        public MemoRepo()
        { }

        public void AddItem(ArtWorkEntity item)
        {
            if (item != null)
            {
                mainCollect.Add(item);
                try
                {
                    SerializeData.ToSerialize(mainCollect);
                }
                catch { }
            }
        }

        public List<ArtWorkEntity> GetAll()
        {
            return mainCollect;
        }

        public ArtWorkEntity GetItem(Guid id)
        {
            return mainCollect.Where(ii => ii.Id == id).First();
        }
    }
}
