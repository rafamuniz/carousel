using CoalServices.Carousel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoalServices.Carousel.Persistence.Repositories
{
    public interface IImageRepository
    {
        /// <summary>
        ///     Add image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Image AddImage(Image image);

        /// <summary>
        ///     Add image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Task<Image> AddImageAsync(Image image);

        /// <summary>
        ///     Delete image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        void DeleteImage(Image image);

        /// <summary>
        ///     Delete image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Task DeleteImageAsync(Guid id);

        /// <summary>
        ///     Get image By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Image GetImageById(Guid id);

        /// <summary>
        ///     Get images
        /// </summary>        
        /// <returns></returns>
        IEnumerable<Image> GetImages();
    }
}
