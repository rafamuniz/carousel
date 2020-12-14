using Microsoft.AspNetCore.Http;
using System;

namespace CoalServices.Carousel.Services
{
    public interface IFileService
    {
        /// <summary>
        ///     Save file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        String Save(IFormFile file, String uniqueFilename, String imageFolder = "\\files");

        /// <summary>
        ///     Get file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Byte[] GetContent(String uniqueFilenameWithExtension, String imageFolder = "\\files");
    }
}
