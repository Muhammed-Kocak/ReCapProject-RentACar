using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImagesDto>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.ImageFile).NotNull();

            RuleFor(x => x.ImageFile.Length).LessThanOrEqualTo(1024 * 500)
                    .WithMessage(Messages.FileSizeError);

            RuleFor(x => x.ImageFile.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                    .WithMessage(Messages.UnsupportedFileType);
        }
    }

    public class AddCarImageValidator : CarImageValidator
    {
        public AddCarImageValidator()
        {
            RuleFor(x => x.CarId).GreaterThan(0).WithMessage(Messages.NotEmpty);
        }
    }

    public class UpdateCarImageValidator : CarImageValidator
    {
        public UpdateCarImageValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage(Messages.NotEmpty);
        }
    }
}
