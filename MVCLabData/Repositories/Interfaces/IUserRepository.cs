using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Repositories.Interfaces
{
    public interface IUserRepository
    {

        IEnumerable<User> All();

        User ByID(Guid id);

        bool AddOrUpdate(User user);

        bool Delete(Guid id);

        User LoginUser(string email, string password);

        bool isEmailTaken(string email);
    }
}