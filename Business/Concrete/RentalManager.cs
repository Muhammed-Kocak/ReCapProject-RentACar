﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    [SecuredOperation("Admin,Moderator,User")]
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("Rental.add")]
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(RentalValidator))]
        public Result Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.EntityAdded);
        }

        [SecuredOperation("Rental.delete")]
        [CacheRemoveAspect("get")]
        public Result Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDeleted);
        }
        [PerformanceAspect(10)]
        [CacheAspect]
        public DataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        [PerformanceAspect(10)]
        [CacheAspect]
        public DataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        [SecuredOperation("Rental.update")]
        [CacheRemoveAspect("get")]
        [ValidationAspect(typeof(RentalValidator))]
        public Result Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
