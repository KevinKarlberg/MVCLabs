using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Repositories.Interfaces
{
    public interface IPictureRepository
    {
        IEnumerable<Picture> All();

        Picture ByID(Guid id);

        bool AddOrUpdate(Picture picture);

        bool Delete(Guid id);
    }
}
