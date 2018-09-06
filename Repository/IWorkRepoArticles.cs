using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public interface IWorkRepoArticles
    {
        void AddItem(Article item);
        List<Article> GetAllByCat(string cat);
        List<Article> GetAll();
        void EraseItem(Guid id);
    }
}
