using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Entity;
using System.IO;
using WebPortfolio.Models;


namespace WebPortfolio.Controllers
{
    public class ShowController : Controller
    {
        private IWorkWithRepo repo = new MemoRepo();
        private IWorkRepoArticles repo2 = new Repo2();
        private Dictionary<Guid, Guid> imagesAll = new Dictionary<Guid, Guid>();

        public ShowController()
        {
            foreach (ArtWorkEntity item in repo.GetAll())
            {
                foreach (var it in item.images)
                {
                    imagesAll.Add(it.IdOwn, it.id);
                }
            }
        }

        public FileContentResult GetRndImage(int z)
        {
            Random rand = new Random();
            List<FileContentResult> coll = new List<FileContentResult>();
            int ii;
            for (var i = 0; i < 10; i++)
            {
                ii = rand.Next(imagesAll.Count);
                coll.Add(ShowImg(imagesAll.Values.ElementAt(ii), imagesAll.Keys.ElementAt(ii)));
            }

            return coll[z];
        }


        public ActionResult Index(int numDrop = 0)
        {
            List<ArtWorkModel> coll = new List<ArtWorkModel>();
            foreach (ArtWorkEntity item in repo.GetAll().Skip(numDrop).Take(3))
            {
                ArtWorkModel currentModel = new ArtWorkModel();
                currentModel.Id = item.Id;
                currentModel.Category = item.category;
                currentModel.Description = item.description;
                currentModel.Images = new List<OneImageModel>();
                foreach (var it in item.images)
                    currentModel.Images.Add(new OneImageModel { IdOwn = it.IdOwn });
                coll.Add(currentModel);
            }
            return View(coll);
        }

        public ActionResult IndexPartial(int numDrop = 0)
        {
            List<ArtWorkModel> coll = new List<ArtWorkModel>();
            foreach (ArtWorkEntity item in repo.GetAll().Skip(numDrop).Take(3))
            {
                ArtWorkModel currentModel = new ArtWorkModel();
                currentModel.Id = item.Id;
                currentModel.Category = item.category;
                currentModel.Description = item.description;
                currentModel.Images = new List<OneImageModel>();
                foreach (var it in item.images)
                    currentModel.Images.Add(new OneImageModel { IdOwn = it.IdOwn });
                coll.Add(currentModel);
            }
            return PartialView("Partial3", coll);
        }

        public ActionResult ArticlesAbout()
        {
            List<ArticleModel> coll = new List<ArticleModel>();
            foreach (Article item in repo2.GetAllByCat("О нас"))
            {
                ArticleModel currentModel = new ArticleModel();

                currentModel.Category = item.Category;
                currentModel.Header = item.Header;
                currentModel.Text = item.Text;
                currentModel.Image1 = new OneImageModel();
                try
                {
                    currentModel.Image1.IdOwn = item.Image1.IdOwn;
                }
                catch { };

                coll.Add(currentModel);
            }
            return PartialView("Partial1", coll);
        }

        public ActionResult ArticlesOur()
        {
            List<ArticleModel> coll = new List<ArticleModel>();
            foreach (Article item in repo2.GetAllByCat("Наши услуги"))
            {
                ArticleModel currentModel = new ArticleModel();

                currentModel.Category = item.Category;
                currentModel.Header = item.Header;
                currentModel.Text = item.Text;
                currentModel.Image1 = new OneImageModel();
                try
                {
                    currentModel.Image1.IdOwn = item.Image1.IdOwn;
                }
                catch { };

                coll.Add(currentModel);
            }
            return PartialView("Partial1", coll);
        }

        public ActionResult ListAllArticles()
        {
            List<ArticleModel> coll = new List<ArticleModel>();
            foreach (Article item in repo2.GetAll())
            {
                ArticleModel currentModel = new ArticleModel();

                currentModel.Id = item.Id;
                currentModel.Category = item.Category;
                currentModel.Header = item.Header;
                currentModel.Text = item.Text;
                currentModel.Image1 = new OneImageModel();
                try
                {
                    currentModel.Image1.IdOwn = item.Image1.IdOwn;
                }
                catch { };

                coll.Add(currentModel);
            }
            return View("PartialForEdit", coll);
        }

        public FileContentResult ShowImgOfArticle(Guid id)
        {

            try
            {
                OneImage slide = repo2.GetAll().Where(it => it.Image1.IdOwn == id).First().Image1;
                return File(slide.ImageData, slide.ImageMimeType);
            }
            catch
            {
                return null;
            }

        }

        public FileContentResult ShowImg(Guid id, Guid idSlide)
        {

            OneImage slide = repo.GetItem(id).images.Where(ii => ii.IdOwn == idSlide).First();
            if (slide.ImageData.Count() == 0) return null;
            return File(slide.ImageData, slide.ImageMimeType);

        }

        
	}
}