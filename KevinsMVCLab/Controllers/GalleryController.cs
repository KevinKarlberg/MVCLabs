using KevinsMVCLab.HelperClasses;
using KevinsMVCLab.ViewModels;
using MVCLabb.Data.Repositories;
using MVCLabData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace KevinsMVCLab.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        private IGalleryRepository repo;

        public GalleryController()
        {
            this.repo = new GalleryRepository();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var galleries = new List<GalleryViewModel>();

            var galleriesFromDB = repo.All();

            if (galleriesFromDB != null)
            {
                foreach (var gallery in galleriesFromDB)
                {
                    var galleryToAdd = ModelMapper.EntityToModel(gallery);
                    galleries.Add(galleryToAdd);
                }
            }


            return View(galleries);
        }
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            GalleryViewModel galleryToView = null;

            var galleryID = id;

            galleryToView = ModelMapper.EntityToModel(repo.ByID(galleryID));
            


            if (galleryToView != null)
            {
                return View(galleryToView);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {

            return View(new GalleryViewModel());
        }
        [HttpPost]
        public ActionResult Create(GalleryViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var accUserName = User.Identity.Name;
                model.id = Guid.NewGuid();
                if (accUserName != null)
                {

                    var entity = ModelMapper.ModelToEntity(model);
                    entity.User = User.Identity.Name;
                    entity.DateCreated = DateTime.Now;
                    repo.AddOrUpdate(entity);
                }
                return RedirectToAction("Index", "Gallery");
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [AllowAnonymous]
        
        public ActionResult Delete(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var galleryToRemove = repo.ByID(id);

                if (galleryToRemove.User == User.Identity.Name)
                {

                    if (galleryToRemove.Pictures != null)
                    {
                        foreach (var picture in galleryToRemove.Pictures)
                        {
                            var filePath = Request.MapPath(picture.Path);
                            FileInfo file = new FileInfo(filePath);
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    }


                    if (repo.Delete(galleryToRemove.id))
                        return Content("Gallery deleted!");
                    else
                        return Content("Couldn't delete gallery");

                }
            }
            return Content("Couldn't delete gallery");

        }

        public ActionResult GalleryList()
        {
            var galleryList = new List<GalleryViewModel>();
            foreach (var gallery in repo.All())
            {
                galleryList.Add(ModelMapper.EntityToModel(gallery));
            }


            return PartialView("_GalleryListView", galleryList);
        }
    }
}
