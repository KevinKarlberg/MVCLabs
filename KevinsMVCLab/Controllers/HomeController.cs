using KevinsMVCLab.HelperClasses;
using KevinsMVCLab.ViewModels;
using MVCLabData.Repositories.Interfaces;
using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KevinsMVCLab.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IPictureRepository repo { get; set; }
        public HomeController(IPictureRepository repo)
        {
            this.repo = repo;
        }
        // GET: Home
        public ActionResult Index()
        {

            var newestPictures = new List<PictureViewModel>();
            var picturesFromDB = repo.All().OrderByDescending(x => x.DatePosted).Take(5).ToList();
            foreach (var pic in picturesFromDB)
            {
                newestPictures.Add(ModelMapper.EntityToModel(pic));
            }


            return View(newestPictures);
        }
    }
}