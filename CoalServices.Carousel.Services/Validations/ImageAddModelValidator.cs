using CoalServices.Carousel.Models;
using FluentValidation;

namespace CoalServices.Carousel.Services.Validations
{
    public class ImageAddModelValidator : AbstractValidator<ImageAddModel>
    {
        public ImageAddModelValidator()
        {
            RuleFor(x => x.Image)
                .NotNull()
                .NotEmpty()
                .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png")).WithMessage("File type is not allowed")
                ;
            ;
        }
    }
}
