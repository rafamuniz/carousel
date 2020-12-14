using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoalServices.Carousel.Models
{
    public class ImageAddModel
    {
        [Required(ErrorMessage = "Please choose an image")]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        public IList<String> Messages { get; set; }
    }
}