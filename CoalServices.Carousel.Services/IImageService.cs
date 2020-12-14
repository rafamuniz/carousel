using CoalServices.Carousel.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoalServices.Carousel.Services
{
    public interface IImageService
    {
        /// <summary>
        ///     Add an image
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>        
        Task<(ImageInfoModel Data, Boolean IsSuccessful, String ErrorMessage)> AddImageAsync(ImageAddModel model);

        /// <summary>
        ///     Get images
        /// </summary>        
        /// <returns></returns>
        IEnumerable<ImageInfoModel> GetImages();

        /// <summary>
        ///     Get images
        /// </summary>        
        /// <returns></returns>
        (ImageInfoModel Data, Boolean IsSuccessful, String ErrorMessage) DeleteImage(Guid id);
    }
}
