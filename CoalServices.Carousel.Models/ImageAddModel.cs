using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoalServices.Carousel.Models
{
    public class ImageAddModel
    {
        [Required(ErrorMessage = "Please choose an image")]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        public String Message{ get; set; }
    }
}