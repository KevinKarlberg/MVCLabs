using Kunskapskollen.Repositories;
using KunskapskollenSite.HelperClasses;
using KunskapskollenSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KunskapskollenSite.Controllers
{
    [AllowAnonymous]
    public class AdressbookController : Controller
    {
        IRepository db = new PersonAdressRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return PartialView("ListAdress", db.All().ToModel());
        }
        [HttpPost]
        public ActionResult Create(AdressViewModel Model)
        {
            db.addOrEdit(Model.ToDb());
            return List();
        }
        [HttpPost]
        public ActionResult Edit(Guid id)
        {
            var model = db.One(id).ToModel();
            return PartialView("_EditPartialView", model);
        }
        [HttpPost]
        public ActionResult SaveEdit(AdressViewModel Model)
        {
            Model.Updaterades = DateTime.Now;
            db.addOrEdit(Model.ToDb());
            return PartialView("_ViewAdress", Model);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            db.Delete(id);
            return PartialView("_Empty");
        }
        public ActionResult Details(Guid Id)
        {
            //FIX
            return View();
        }
    }
}