using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(c => c.CompanyName).MinimumLength(1).WithMessage(Messages.MinimumLenght);
        }
    }
}
