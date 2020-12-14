using CoalServices.Carousel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoalServices.Carousel.Persistence.Configurations
{
    internal class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Entities.Image> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .ToTable("Images", "dbo");

            builder.Property(e => e.Content)
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired()
                ;

            builder.Property(e => e.FileName)
                .HasColumnType("VARCHAR(256)")
                .IsRequired()
                ;

            builder.Property(e => e.FileExtension)
                .HasColumnType("VARCHAR(16)")
                .IsRequired()
                ;

            builder.Property(e => e.ContentType)
                .HasColumnType("VARCHAR(64)")
                .IsRequired()
                ;

            builder.Property(e => e.FileSize)
                .HasColumnType("BIGINT")
                .IsRequired()
                ;

            builder.Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .IsRequired()
                ;

            builder.Property(e => e.RowVersion)
                .HasColumnType("Timestamp")
                .IsRequired()
                ;
        }
    }
}
