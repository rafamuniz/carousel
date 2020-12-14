using AutoMapper;
using CoalServices.Carousel.Entities;
using CoalServices.Carousel.Models;
using CoalServices.Carousel.Persistence;
using CoalServices.Carousel.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ILogger<ImagesController> _logger;
        private readonly IImageService _imageService;

        public ImagesController(
            ILogger<ImagesController> logger,
            IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var images = _imageService.GetImages();
            return View(images);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ImageAddModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _imageService.AddImageAsync(model);

                if (result.IsSuccessful)
                {
                    return RedirectToAction("Index", "Images");
                }

                model.Message = result.ErrorMessage;
            }

            return View(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _imageService.DeleteImage(id);

            if (result.IsSuccessful)
            {
                return RedirectToAction("Index", "Images");
            }

            return View();
        }

        public IActionResult Gets()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
