using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        IUserDal _userDal;

        public UserValidator(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.EMail).MinimumLength(10);
            RuleFor(u => u.EMail).EmailAddress();
            RuleFor(u => u.EMail).Must(IsEmailUnique).WithMessage("Aynı E-Mail'den Mevcut. LÜTFEN GİRİŞ YAPINIZ!");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
            RuleFor(u => u.Password).MaximumLength(30);

        }

        private bool IsEmailUnique(string arg)
        {
            var result = _userDal.Get(c => c.EMail == arg);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
