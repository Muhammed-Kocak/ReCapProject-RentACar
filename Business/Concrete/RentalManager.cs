﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public Result Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.EntityAdded);
        }

        public Result Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public DataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public DataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public Result Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}