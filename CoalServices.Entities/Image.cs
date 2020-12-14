using System;
using System.ComponentModel.DataAnnotations;

namespace CoalServices.Carousel.Entities
{
    public class Image : TKey<Guid>
    {
        public Image()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Byte[] Content { get; set; }
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String ContentType { get; set; }

        public Int64 FileSize { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
