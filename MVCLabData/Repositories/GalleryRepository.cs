using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLabData.Tables;
using System.Data.Entity;
using MVCLabData.Repositories.Interfaces;
using MVCLabData;

namespace MVCLabb.Data.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        public bool AddOrUpdate(Gallery gallery)
        {
            try
            {
                using (var ctx = new MVCLabDataDbContext())
                {
                    var galleryToUpdate = ctx.Galleries.Where(g => g.id == gallery.id)
                            .Include(g => g.Pictures)
                            .FirstOrDefault();
                    if (galleryToUpdate != null)
                    {
                        galleryToUpdate.GalleryName = gallery.GalleryName;
                        ctx.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var newGallery = new Gallery();
                        newGallery.User = gallery.User;
                        newGallery.GalleryName = gallery.GalleryName;
                        newGallery.DateCreated = DateTime.Now;
                        newGallery.id = gallery.id;
                        ctx.Galleries.Add(newGallery);
                        ctx.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                // handle exceptions
            }

            return false;

        }

        public IEnumerable<Gallery> All()
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var galleries = ctx.Galleries
                            .Include(g => g.Pictures);

                return galleries.ToList();
            }
        }

        public Gallery ByID(Guid id)
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var gallery = ctx.Galleries.Where(g => g.id == id)
                            .Include(g => g.Pictures)
                            .FirstOrDefault();
                return gallery;
            }
        }

        public bool Delete(Guid id)
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var gallery = ctx.Galleries.FirstOrDefault(g => g.id == id);
                            

                if (gallery != null)
                {
                    try
                    {
                        ctx.Galleries.Remove(gallery);
                        ctx.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                 
                }
                return false;
            }
        }
    }
}
