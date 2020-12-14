using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CoalServices.Carousel.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;

        public FileService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        /// <summary>
        ///     Save file
        /// </summary>
        /// <param name="file">IFormFile</param>
        /// <param name="uniqueFilename">String</param>
        /// <param name="imageFolder">String</param>
        /// <returns></returns>
        public String Save(IFormFile file, String uniqueFilename, String imageFolder = "\\files")
        {
            var filePath = String.Empty;

            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                var path = $"{_environment.WebRootPath}{imageFolder}";
                filePath = $"{_environment.WebRootPath}{imageFolder}\\{uniqueFilename}{fileExtension}";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return filePath;
        }

        /// <summary>
        ///     Get file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Byte[] GetContent(String uniqueFilenameWithExtension, String imageFolder = "\\files")
        {
            var path = $"{_environment.WebRootPath}{imageFolder}";
            var pathFilename = $"{path}\\{uniqueFilenameWithExtension}";

            if (!File.Exists(pathFilename))
            {
                throw new FieldAccessException("File not found");
            }

            return File.ReadAllBytes(pathFilename);
        }
    }
}
