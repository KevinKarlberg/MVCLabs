using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MVCLabData.Repositories.Interfaces
{
    public class ICommentRepository
    {
        IEnumerable<Comment> All();

        Comment ByID(int id);

        bool AddOrUpdate(Comment comment);

        bool Delete(int id);
    }
}