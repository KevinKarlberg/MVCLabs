using KevinsMVCLab.HelperClasses;
using KevinsMVCLab.ViewModels;
using MVCLabData;
using MVCLabData.Repositories;
using MVCLabData.Repositories.Interfaces;
using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace KevinsMVCLab.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        // GET: Comment
        // Added comment to try

        private ICommentRepository repo;
        public CommentController()
        {
            this.repo = new CommentRepository();
        }
        // GET: Comment
        [AllowAnonymous]
        public ActionResult Comments(Guid pictureID)
        {
            var comments = new List<CommentViewModel>();


            var commentsFromDB = repo.All().Where(x => x.PictureID == pictureID);

            foreach (var comment in commentsFromDB)
            {
                comments.Add(ModelMapper.EntityToModel(comment));
            }


            return PartialView(comments);
        }

        public ActionResult NewComment(PictureViewModel picture)
        {
            var repo = new CommentRepository();
            var list = new List<Comment>();
            var commentlist = repo.All().ToList();
            for (int i = 0; i < commentlist.Count; i++)
            {
                if (commentlist[i].PictureID == picture.id)
                    list.Add(commentlist[i]);
            }
            var commentViewModelList = new List<CommentViewModel>();
            for (int i = 0; i < list.Count; i++)
            {
                commentViewModelList.Add(ModelMapper.EntityToModel(list[i]));
            }
            return View(commentViewModelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewComment(CommentViewModel model)
        {

            var identity = (ClaimsIdentity)User.Identity;
            model.User = User.Identity.Name;

            model.DatePosted = DateTime.Now;


            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {

                var newComment = ModelMapper.ModelToEntity(model);
                repo.AddOrUpdate(newComment);
                return Content("Comment added");

            }

            return Content("Couldn't add comment");
        }
        [HttpPost]
        public ActionResult Delete(Guid commentID)
        {
            if (User.Identity.IsAuthenticated)
            {


                using (var ctx = new MVCLabDataDbContext())
                {
                    var commentToRemove = repo.ByID(commentID);
                    if (commentToRemove != null)
                    {
                        repo.Delete(commentID);
                    }
                    return Content("Comment was removed.");
                }

            }
            return Content("Couldn't remove comment.");
        }
    }
}