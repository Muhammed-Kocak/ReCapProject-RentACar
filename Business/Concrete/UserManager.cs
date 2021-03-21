using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
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
        [CacheAspect(5)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [CacheAspect(5)]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
