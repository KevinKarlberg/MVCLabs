using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KunskapskollenSite.Models
{
    public class AdressViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Namn { get; set; }
        [Required]
        public string Telefonnummer { get; set; }
        [Required]
        public string Adress { get; set; }
        public DateTime Updaterades { get; set; }
    }
}