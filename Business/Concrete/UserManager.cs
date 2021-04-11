using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private  ICustomerDal _customerDal;
        private  IFindeksDal _findeksDal;
        private  IFindeksService _findeksService;
        private  IUserDal _userDal;

        public UserManager(ICustomerDal customerDal, IFindeksDal findeksDal, IFindeksService findeksService,
            IUserDal userDal)
        {
            _customerDal = customerDal;
            _findeksDal = findeksDal;
            _findeksService = findeksService;
            _userDal = userDal;
        }
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.EntityAdded);
        }
        [CacheRemoveAspect("get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.EntityDeleted);
        }
        [CacheAspect(5)]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        [CacheAspect(5)]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
        }
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.EntityUpdated);
        }
        //[SecuredOperation("user")]
        public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var user = GetById(userDetailForUpdate.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash,
                user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

            user.FirstName = userDetailForUpdate.FirstName;
            user.LastName = userDetailForUpdate.LastName;
            if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userDal.Update(user);

            var customer = _customerDal.Get(c => c.CustomerId == userDetailForUpdate.CustomerId);
            customer.CompanyName = userDetailForUpdate.CompanyName;
            _customerDal.Update(customer);

            if (!string.IsNullOrEmpty(userDetailForUpdate.NationalIdentity))
            {
                var findeks = _findeksService.GetByCustomerId(userDetailForUpdate.CustomerId).Data;
                if (findeks == null)
                {
                    var newFindeks = new Findeks
                    {
                        CustomerId = userDetailForUpdate.CustomerId,
                        NationalIdentity = userDetailForUpdate.NationalIdentity
                    };
                    _findeksService.Add(newFindeks);
                }
                else
                {
                    findeks.NationalIdentity = userDetailForUpdate.NationalIdentity;
                    var newFindeks = _findeksService.CalculateFindeksScore(findeks).Data;
                    _findeksDal.Update(newFindeks);
                }
            }

            return new SuccessResult(Messages.UserDetailsUpdated);
        }
        [CacheAspect(5)]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        [CacheAspect(5)]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        public IDataResult<UserDetailDto> GetUserDetailByMail(string userMail)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(userMail));
        }
    }
}
