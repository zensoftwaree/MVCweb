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
    public class ModifyController : Controller
    {
        private IWorkWithRepo repo = new MemoRepo();
        private IWorkRepoArticles repo2 = new Repo2();
               

        [HttpPost]
        public ActionResult AddNew(ArtWorkModel item, IEnumerable<HttpPostedFileBase> uploads)
        {
            ArtWorkEntity temp = new ArtWorkEntity();
            temp.category = item.Category;
            temp.description = item.Description;
            if (uploads!=null) temp.images = new List<OneImage>();
            foreach (var upload in uploads)
            {
                if (upload != null)
                {
                    OneImage im = new OneImage();
                    im.id = temp.Id;
                    im.ImageMimeType = upload.ContentType;
                    im.ImageData = new byte[upload.ContentLength];
                    upload.InputStream.Read(im.ImageData, 0, upload.ContentLength);
                    
                    temp.images.Add(im);
                }
            }
            repo.AddItem(temp);

            ArtWorkModel currentModel = new ArtWorkModel();
            currentModel.Id = temp.Id;
            currentModel.Category = temp.category;
            currentModel.Description = temp.description;
            currentModel.Images = new List<OneImageModel>();
            foreach (var it in temp.images)
                currentModel.Images.Add(new OneImageModel { IdOwn = it.IdOwn });

            return View("Partial2", currentModel);
           
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View("Partial1");
        }

        public ActionResult AddNewArticle()
        {
            return View("Partial4");
        }

        [HttpPost]
        public ActionResult AddNewArticle(ArticleModel item, HttpPostedFileBase upload)
        {
            Article temp = new Article();
            temp.Category = item.Category;
            temp.Header = item.Header;
            temp.Text = item.Text;
            if(upload != null)
            {
                OneImage im = new OneImage();
                
                im.ImageMimeType = upload.ContentType;
                im.ImageData = new byte[upload.ContentLength];
                upload.InputStream.Read(im.ImageData, 0, upload.ContentLength);
                temp.Image1 = im;
            }
            
            repo2.AddItem(temp);

            return RedirectToAction("ListAllArticles", "Show", null);
        }

        public ActionResult EraseArticle(Guid id)
        {
            repo2.EraseItem(id);
            return RedirectToAction("ListAllArticles", "Show", null);
        }
	}
}