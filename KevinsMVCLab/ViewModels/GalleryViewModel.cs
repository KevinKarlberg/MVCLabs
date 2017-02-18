using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KevinsMVCLab.ViewModels
{
    public class GalleryViewModel
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum 5, Maximum 50 Characters")]
        [Display(Name = "Gallery Name")]
        public string GalleryName { get; set; }

        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        public string UserName { get; set; }

        public UserViewModel User { get; set; }
    }
}