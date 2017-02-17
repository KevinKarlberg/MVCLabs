using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;


namespace MVCLabData.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> All();

        Comment ByID(Guid id);

        bool AddOrUpdate(Comment comment);

        bool Delete(Guid id);
    }
}