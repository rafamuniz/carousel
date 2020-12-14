using System;

namespace CoalServices.Carousel.Models
{
    public class ImageInfoModel
    {
        public Guid Id { get; set; }

        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String ContentType { get; set; }
        public Int64 FileSize { get; set; }

        public Byte[] Content { get; set; }

        public String ContentBase64
        {
            get
            {
                var base64 = Convert.ToBase64String(Content);
                return $"data:{ContentType};base64,{base64}";
            }
        }

        public DateTime CreatedOn { get; set; }
    }
}
