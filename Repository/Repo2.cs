using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public class Repo2 : IWorkRepoArticles
    {
        private static List<Article> mainCollect;
        
        static Repo2()
        {
            mainCollect = new List<Article>();

            try
            {
                mainCollect = SerializeData.DeSerializeArticle("binary2.dat").ToList();
            }
            catch { }
        }

        public Repo2()
        { }

        public void AddItem(Article item)
        {
            if (item != null)
            {
                mainCollect.Add(item);
                try
                {
                    SerializeData.ToSerialize(mainCollect, "binary2.dat");
                }
                catch { }
            }
        }

        public List<Article> GetAllByCat(string cat)
        {
            return mainCollect.Where(it => it.Category.Contains(cat)).ToList<Article>();
            
        }

        public List<Article> GetAll()
        {
            
            return mainCollect;
        }

        public void EraseItem(Guid id)
        {
            Article item = mainCollect.FirstOrDefault(it => it.Id == id);
            if (item != null)
            {
                mainCollect.RemoveAll(it => it.Id == id);
                try
                {
                    SerializeData.ToSerialize(mainCollect, "binary2.dat");
                }
                catch { }
            }
        }

    }
}
