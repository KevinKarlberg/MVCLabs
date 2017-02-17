using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVCLabData.Repositories.Interfaces;
using MVCLabData.Tables;
using MVCLabData;

namespace MVCLabb.Data.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        public bool AddOrUpdate(Picture picture)
        {
            try
            {
                using (var ctx = new MVCLabDataDbContext())
                {
                    var pictureToUpdate = ctx.Pictures.Where(p => p.id == picture.id)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Gallery)
                        .FirstOrDefault();


                    if (pictureToUpdate != null)
                    {
                        pictureToUpdate.Name = picture.Name;
                        pictureToUpdate.GalleryID = picture.GalleryID;
                        pictureToUpdate.Path = picture.Path;
                        pictureToUpdate.@public = picture.@public;
                        pictureToUpdate.Description = picture.Description;
                        pictureToUpdate.DateEdited = picture.DateEdited;
                        ctx.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var newPicture = new Picture();
                        newPicture.Name = picture.Name;
                        newPicture.GalleryID = picture.GalleryID;
                        newPicture.Path = picture.Path;
                        newPicture.@public = picture.@public;
                        newPicture.Description = picture.Description;
                        newPicture.DateEdited = picture.DateEdited;
                        newPicture.DatePosted = picture.DatePosted;
                        newPicture.UserID = picture.UserID;
                        ctx.Pictures.Add(newPicture);
                        ctx.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Handle exceptions
            }
            return false;
        }

        public IEnumerable<Picture> All()
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var pictures = ctx.Pictures
                        .Include(p => p.Comments)
                        .Include(p => p.Gallery)
                        .Include(p => p.User);
                return pictures.ToList();
            }
        }

        public Picture ByID(Guid id)
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var picture = ctx.Pictures.Where(p => p.id == id)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Gallery)
                        .FirstOrDefault();
                return picture;
            }
        }

        public bool Delete(Guid id)
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var picture = ctx.Pictures.Where(p => p.id == id)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Gallery)
                        .FirstOrDefault();
                if (picture != null)
                {
                    ctx.Pictures.Remove(picture);
                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}