using CoalServices.Carousel.Models;
using CoalServices.Carousel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
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
            _logger.LogInformation("Getting images");
            var result = _imageService.GetImages();

            if (result.IsSuccessful)
            {
                return View(result.Data);
            }

            return View(new ErrorViewModel { Message = result.ErrorMessage });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ImageAddModel model)
        {
            _logger.LogInformation("Validating ");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding image");
                var result = await _imageService.AddImageAsync(model);

                if (result.IsSuccessful)
                {
                    _logger.LogInformation("Image added");
                    return RedirectToAction("Index", "Images");
                }

                _logger.LogInformation("Error adding image");
                ModelState.AddModelError("Image", String.Join(", ", result.ErrorMessages.ToArray()));
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

            return View(new ErrorViewModel { Message = result.ErrorMessage });
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
