using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //[SecuredOperation("Admin,Moderator")]
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal,ICarImageService carImageService)
        {
            _carImageService = carImageService;
            _carDal = carDal;
        }
        //[SecuredOperation("Car.add")]
        [CacheRemoveAspect("get")]
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
        [SecuredOperation("Car.delete")]
        [CacheRemoveAspect("get")]
        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.EntityDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.EntityListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.EntityListed);
        }

        public IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId)
        {
            var result = _carDal.GetCarDetail(carId);
            var imageResult = _carImageService.GetImagesByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailAndImagesDto>(Messages.GetErrorCarMessage);
            }

            var carDetailAndImagesDto = new CarDetailAndImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarDetailAndImagesDto>(carDetailAndImagesDto, Messages.GetSuccessCarMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrand(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarByBrand(id));
        }
        public IDataResult<List<CarDetailDto>> GetCarsByColor(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarByColor(id));
        }

        public IDataResult<CarDetailDto> GetCarsDetail(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarsDetail(c=>c.CarId==carId).FirstOrDefault());
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarsDetail(p => p.BrandId == brandId && p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.GetErrorCarMessage);
            }
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetail(), Messages.EntityListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => min <= c.DailyPrice && c.DailyPrice <= max), Messages.EntityListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetModelYear(decimal minyear, decimal maxyear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => minyear <= c.ModelYear && c.ModelYear <= maxyear), Messages.EntityListed);
        }
        //[SecuredOperation("Car.update")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("get")]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.EntityUpdated);
        }

    }
}
