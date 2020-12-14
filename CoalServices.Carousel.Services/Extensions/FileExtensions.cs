using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CoalServices.Carousel.Services.Extensions
{
    public static class FileExtensions
    {
        /// <summary>
        ///     To By Array
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        /// <summary>
        ///     To Base64 String
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static String ToBase64String(this Byte[] file, String contentType)
        {
            var base64 = Convert.ToBase64String(file);
            return $"data:{contentType};base64,{base64}";
        }
    }
}
