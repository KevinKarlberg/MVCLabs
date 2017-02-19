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
        public static Gallery ModelToEntity(GalleryViewModel viewModel)
        {
            var model = new Gallery();
            model.id = viewModel.id;
            model.GalleryName = viewModel.GalleryName;
            model.DateCreated = viewModel.DateCreated;
            model.User = viewModel.User;

            return model;
        }

        public static GalleryViewModel EntityToModel(Gallery model)
        {
            var viewModel = new GalleryViewModel();
            viewModel.id = model.id;
            viewModel.GalleryName = model.GalleryName;
            viewModel.DateCreated = model.DateCreated;
            viewModel.User = model.User;

            return viewModel;
        }



        public static Picture ModelToEntity(PictureViewModel model)
        {
            var pic = new Picture();
            pic.Name = model.Name;
            pic.id = model.id;
            pic.Path = model.Path;
            pic.User = model.User;
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
            model.User = entity.User;
            model.Description = entity.Description;
            model.DatePosted = entity.DatePosted;
            model.DateEdited = entity.DateEdited;
            model.GalleryID = entity.GalleryID;
            model.IsPublicPicture = entity.@public;
            model.Uploader = entity.User;


            return model;


        }

        public static Comment ModelToEntity(CommentViewModel model)
        {
            var entity = new Comment();
            entity.Body = model.Comment;
            entity.id = model.id;
            entity.PictureID = model.PictureID;
            entity.User = model.User;
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
            viewModel.User = model.User;
            viewModel.Title = model.Title;
            viewModel.DateEdited = model.DateEdited;
            viewModel.DatePosted = model.DatePosted;



            return viewModel;
        }




    }
}