using AutoMapper;
using CoalServices.Carousel.Models;
using CoalServices.Carousel.Services.Extensions;

namespace CoalServices.Carousel.Services.Mappings
{
    public class CarouselProfile : Profile
    {
        public CarouselProfile()
        {
            this.CreateMap<ImageAddModel, Entities.Image>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Image != null ? src.Image.ToByteArray() : null))
                ;

            this.CreateMap<Entities.Image, ImageInfoModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => src.FileExtension))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.FileSize, opt => opt.MapFrom(src => src.FileSize))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                ;
        }
    }
}