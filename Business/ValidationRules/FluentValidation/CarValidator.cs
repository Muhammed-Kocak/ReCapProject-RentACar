using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(c => c.ModelYear).GreaterThan(0).WithMessage(Messages.IncorrectYearUse);
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.WrongPriceEntry);
            RuleFor(c => c.Description).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(c => c.Description).MinimumLength(5).WithMessage(Messages.MinimumLenght);
        }
    }
}
