using CoalServices.Carousel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoalServices.Carousel.Persistence.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(CoalServicesContext context)
            : base(context)
        {

        }

        /// <summary>
        ///     Add image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Image AddImage(Image image)
        {
            _context.Images.Add(image);

            return image;
        }

        /// <summary>
        ///     Add image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public async Task<Image> AddImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);

            return image;
        }

        /// <summary>
        ///     Delete image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public void DeleteImage(Image image)
        {
            _context.Images.Remove(image);
        }

        /// <summary>
        ///     Delete image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteImageAsync(Guid id)
        {
            var image = await _context.Images.FindAsync(id);

            _context.Images.Remove(image);
        }

        /// <summary>
        ///     Get image By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Image GetImageById(Guid id)
        {
            return _context.Images.Find(id);
        }

        /// <summary>
        ///     Get images
        /// </summary>        
        /// <returns></returns>
        public IEnumerable<Image> GetImages()
        {
            return _context.Images.AsNoTracking().AsEnumerable();
        }
    }
}
