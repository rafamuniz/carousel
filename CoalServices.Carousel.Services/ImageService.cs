using AutoMapper;
using CoalServices.Carousel.Entities;
using CoalServices.Carousel.Models;
using CoalServices.Carousel.Persistence;
using CoalServices.Carousel.Services.Extensions;
using CoalServices.Carousel.Services.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoalServices.Carousel.Services
{
    public class ImageService : IImageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(
            IMapper mapper,
            CoalServicesContext context)
        {
            _mapper = mapper;
            _unitOfWork = new UnitOfWork(context);
        }

        /// <summary>
        ///     Add an image
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<(ImageInfoModel Data, Boolean IsSuccessful, IList<String> ErrorMessages)> AddImageAsync(ImageAddModel model)
        {
            try
            {
                if (!model.Validate<ImageAddModelValidator, ImageAddModel>().IsValid)
                {
                    var validations = model.Validate<ImageAddModelValidator, ImageAddModel>();

                    return (null, false, validations.ToList());
                }

                var image = _mapper.Map<ImageAddModel, Image>(model);

                image.Content = model.Image.ToByteArray();
                image.FileExtension = Path.GetExtension(model.Image.FileName);
                image.FileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                image.FileSize = model.Image.Length;
                image.ContentType = model.Image.ContentType;

                await _unitOfWork.ImageRepository.AddImageAsync(image);
                await _unitOfWork.CompleteAsync();

                var entityMapped = _mapper.Map<Image, ImageInfoModel>(image);

                return (entityMapped, true, null);
            }
            catch (Exception ex)
            {
                return (null, false, new List<String>() { ex.Message });
            }
        }

        /// <summary>
        ///     Get images
        /// </summary>        
        /// <returns></returns>
        public (IEnumerable<ImageInfoModel> Data, Boolean IsSuccessful, String ErrorMessage) GetImages()
        {
            try
            {
                var images = _unitOfWork.ImageRepository.GetImages();

                var models = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageInfoModel>>(images);

                return (models, true, null);
            }
            catch (Exception ex)
            {
                return (null, false, ex.Message);
            }
        }

        /// <summary>
        ///     Get images
        /// </summary>        
        /// <returns></returns>
        public (ImageInfoModel Data, Boolean IsSuccessful, String ErrorMessage) DeleteImage(Guid id)
        {
            var image = _unitOfWork.ImageRepository.GetImageById(id);

            if (image != null)
            {
                _unitOfWork.ImageRepository.DeleteImage(image);
                return (null, true, null);
            }

            return (null, false, null);
        }
    }
}