using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Repositories.Interfaces
{
    public interface IGalleryRepository
    {

        IEnumerable<Gallery> All();

        Gallery ByID(Guid id);

        bool AddOrUpdate(Gallery gallery);

        bool Delete(Guid id);
    }
}