using Kunskapskollen.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapskollen.Repositories
{
   public  interface IRepository
    {
        void addOrEdit(PersonAdress personAdress);
        void Delete(Guid Id);
        List<PersonAdress> All();
        PersonAdress One(Guid id);
    }
}
