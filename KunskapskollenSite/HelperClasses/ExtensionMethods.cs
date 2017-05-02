using Kunskapskollen.DBModels;
using KunskapskollenSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KunskapskollenSite.HelperClasses
{
    public static class ExtensionMethods
    {
        public static PersonAdress ToDb(this AdressViewModel Model)
        {
            return new PersonAdress()
            {
                Namn = Model.Namn,
                Telefonnummer = Model.Telefonnummer,
                Adress = Model.Adress,
                Updaterades = DateTime.Now,
                Id = Model.Id
            };
        }
        public static AdressViewModel ToModel(this PersonAdress Entity)
        {
            return new AdressViewModel()
            {
                Namn = Entity.Namn,
                Telefonnummer = Entity.Telefonnummer,
                Adress = Entity.Adress,
                Id = Entity.Id,
                Updaterades = (DateTime)Entity.Updaterades

            };
        }
        public static List<AdressViewModel> ToModel(this List<PersonAdress> EntityList)
        {
            var result = new List<AdressViewModel>();
            foreach (var item in EntityList)
            {
                result.Add(item.ToModel());
            }
            return result;
        }
    }
}