using KevinsMVCLab.ViewModels;
using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KevinsMVCLab.HelperClasses
{
    public class ModelMapper
    {
        public static User ModelToEntity(UserViewModel model)
        {
            var user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.id = model.id;

            return user;

        }

        public static UserViewModel EntityToModel(User model)
        {
            var viewModel = new UserViewModel();
            viewModel.FirstName = model.FirstName;
            viewModel.LastName = model.LastName;
            viewModel.Email = model.Email;
            viewModel.id = model.id;

            return viewModel;


        }

        public static Gallery ModelToEntity(GalleryViewModel viewModel)
        {
            var model = new Gallery();
            model.id = viewModel.id;
            model.GalleryName = viewModel.GalleryName;
            model.DateCreated = viewModel.DateCreated;
            model.UserID = viewModel.UserID;

            return model;
        }

        public static GalleryViewModel EntityToModel(Gallery model)
        {
            var viewModel = new GalleryViewModel();
            viewModel.id = model.id;
            viewModel.GalleryName = model.GalleryName;
            viewModel.DateCreated = model.DateCreated;
            viewModel.UserID = model.UserID;
            viewModel.User = EntityToModel(model.User);

            return viewModel;
        }



        public static Picture ModelToEntity(PictureViewModel model)
        {
            var pic = new Picture();
            pic.Name = model.Name;
            pic.id = model.id;
            pic.Path = model.Path;
            pic.UserID = model.UserID;
            pic.Description = model.Description;
            pic.DatePosted = model.DatePosted;
            pic.DateEdited = model.DateEdited;
            pic.GalleryID = model.GalleryID;
            pic.@public = model.IsPublicPicture;





            return pic;

        }

        public static PictureViewModel EntityToModel(Picture entity)
        {
            var model = new PictureViewModel();
            model.Name = entity.Name;
            model.id = entity.id;
            model.Path = entity.Path;
            model.UserID = entity.UserID;
            model.Description = entity.Description;
            model.DatePosted = entity.DatePosted;
            model.DateEdited = entity.DateEdited;
            model.GalleryID = entity.GalleryID;
            model.IsPublicPicture = entity.@public;
            model.Uploader = entity.User.FirstName + " " + entity.User.LastName;


            return model;


        }

        public static Comment ModelToEntity(CommentViewModel model)
        {
            var entity = new Comment();
            entity.Body = model.Comment;
            entity.id = model.id;
            entity.PictureID = model.PictureID;
            entity.UserID = model.UserID;
            entity.Title = model.Title;
            entity.DateEdited = model.DateEdited;
            entity.DatePosted = model.DatePosted;

            return entity;
        }

        public static CommentViewModel EntityToModel(Comment model)
        {
            var viewModel = new CommentViewModel();
            viewModel.Comment = model.Body;
            viewModel.id = model.id;
            viewModel.PictureID = model.PictureID;
            viewModel.Picture = EntityToModel(model.Picture);
            viewModel.UserID = model.UserID;
            viewModel.User = EntityToModel(model.User);
            viewModel.Title = model.Title;
            viewModel.DateEdited = model.DateEdited;
            viewModel.DatePosted = model.DatePosted;



            return viewModel;
        }




    }
}