using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            if (entity.DailyPrice > 0)
            {
                _carDal.Add(entity);
                return new SuccessResult(Messages.EntityAdded);
            }
            else
            {
                return new ErrorResult(Messages.WrongPriceEntry);
            }
        }
        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.EntityDeleted);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.EntityListed);
        }
        public IDataResult<Car> GetBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == id), Messages.EntityListed);
        }
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.EntityListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.EntityListed);
        }
        IDataResult<List<Car>> ICarService.GetCarDetails()
        {
            throw new NotImplementedException();
        }
        public IDataResult<Car> GetColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == id), Messages.EntityListed);
        }
        public IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => min <= c.DailyPrice && c.DailyPrice <= max), Messages.EntityListed);
        }
        public IDataResult<List<Car>> GetModelYear(decimal minyear, decimal maxyear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => minyear <= c.ModelYear && c.ModelYear <= maxyear), Messages.EntityListed);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
