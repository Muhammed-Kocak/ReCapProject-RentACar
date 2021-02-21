﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(c => c.ColorName).MinimumLength(2).WithMessage(Messages.MinimumLenght);
        }
    }
}
