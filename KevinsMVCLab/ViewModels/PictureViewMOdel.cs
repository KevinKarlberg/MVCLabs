﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KevinsMVCLab.ViewModels
{
    public class PictureViewModel
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Max 140 characters, minimum 5", MinimumLength = 5)]
        public string Description { get; set; }
        public string Path { get; set; }
        public string User { get; set; }
        [Display(Name = "Posted")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Edited")]
        public DateTime? DateEdited { get; set; }
        [Required]
        [Display(Name = "Public")]
        public bool IsPublicPicture { get; set; }
        public Guid GalleryID { get; set; }
        public string Uploader { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}