using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        IRentalDal _rentalDal;

        public RentalValidator(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(r => r.RentDate).Must(CheckDate).WithMessage(Messages.CheckDate);
            RuleFor(r => r.ReturnDate).Empty().WithMessage(Messages.Empty);
            RuleFor(r => r.ReturnDate).Must(CheckRent).WithMessage(Messages.CheckRent);
        }

        private bool CheckRent(DateTime? arg)
        {
            var result = _rentalDal.Get(r => r.ReturnDate != null);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        private bool CheckDate(DateTime arg)
        {
            arg = DateTime.Now;
            var result = _rentalDal.Get(r => r.RentDate == arg || r.RentDate >= arg);
            if (result !=null )
            {
                return true;
            }
            return false;
        }
    }
}
