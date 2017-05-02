using Kunskapskollen;
using Kunskapskollen.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapskollen.Repositories
{
    public class PersonAdressRepository : IRepository,IDisposable
    {
        public void addOrEdit(PersonAdress personAdress)
        {
            using (var ctx = new AdressbookDBContext())
            {
                var Entity = ctx.PersonAdress.FirstOrDefault(x => x.Id == personAdress.Id)
                ?? new PersonAdress() { Id = Guid.NewGuid() };
                Entity.Namn = personAdress.Namn;
                Entity.Adress = personAdress.Adress;
                Entity.Telefonnummer = personAdress.Telefonnummer;
                Entity.Updaterades = DateTime.Now;

                ctx.PersonAdress.Add(Entity);
                ctx.SaveChanges();
            }
        }

        public List<PersonAdress> All()
        {
            using (var ctx = new AdressbookDBContext())
            {
                var all = ctx.PersonAdress.ToList()
                    ?? new List<PersonAdress>();
                return all;
            }
        }

        public void Delete(Guid Id)
        {
            using (var ctx = new AdressbookDBContext())
            {
                var EntityToDelete = ctx.PersonAdress.FirstOrDefault(x => x.Id == Id);
                ctx.PersonAdress.Remove(EntityToDelete);
                ctx.SaveChanges();
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PersonAdress One(Guid id)
        {
            using (var ctx = new AdressbookDBContext())
            {
                return ctx.PersonAdress.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
