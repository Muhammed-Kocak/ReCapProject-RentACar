using Business.Constants;
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
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage(Messages.MinimumLenght);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage(Messages.MinimumLenght);
            RuleFor(u => u.EMail).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.EMail).MinimumLength(10).WithMessage(Messages.MinimumLenght);
            RuleFor(u => u.EMail).EmailAddress().WithMessage(Messages.EmailCheck);
            RuleFor(u => u.EMail).Must(IsEmailUnique).WithMessage(Messages.IsEmailUnique);
            RuleFor(u => u.Password).NotEmpty().WithMessage(Messages.NotEmpty);
            RuleFor(u => u.Password).MinimumLength(6).WithMessage(Messages.MinimumLenght);
            RuleFor(u => u.Password).MaximumLength(30).WithMessage(Messages.MaximumLenght);

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
