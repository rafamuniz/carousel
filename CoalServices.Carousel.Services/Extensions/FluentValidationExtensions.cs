using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CoalServices.Carousel.Services.Extensions
{
    public static class FluentValidationExtensions
    {
        public static ValidationResult Validate<TValidator, TEntity>(this TEntity source)
          where TValidator : AbstractValidator<TEntity>
        {
            return Activator.CreateInstance<TValidator>().Validate(source);
        }

        public static List<String> ToList(this ValidationResult source)
        {
            List<String> errors = new List<string>();
            foreach (var error in source.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            return errors;
        }
    }
}
