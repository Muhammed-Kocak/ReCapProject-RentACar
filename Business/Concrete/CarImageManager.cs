using Autofac;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //[SecuredOperation("Admin,Moderator")]
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImageDal;

        public CarImageManager(ICarImagesDal carImagesDal)
        {
            _carImageDal = carImagesDal;
        }
        //[SecuredOperation("Car.add")]
        [CacheRemoveAspect("get")]
        public IResult Add(CarImage entity)
        {
            var result = BusinessRules.Run(CheckCarImageCount());
            if (result != null)
            {
                return result;
            }
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.CarImageAdded);
        }
        [SecuredOperation("Car.delete")]
        [CacheRemoveAspect("get")]
        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.CarId == entity.CarId);
            File.Delete(@"wwwroot\images\" + imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfCarId(id));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }
            var getAllbyCarIdResult = _carImageDal.GetAll(c => c.CarImageId == id);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = FilePath.ImageDefaultPath } });
            }
            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        [SecuredOperation("Car.update")]
        [CacheRemoveAspect("get")]
        public IResult Update(CarImage entity)
        {
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.EntityUpdated);
        }
        private IResult CheckCarImageCount()
        {
            if (_carImageDal.GetAll().Count > 4)
            {
                return new ErrorResult(Messages.CarImageAddLimit);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarId(int carId)
        {
            var carService = ServiceTool.AutofacServiceProvider.Resolve<ICarService>();
            if (!carService.GetById(carId).Success)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.GetErrorCarDetails);
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = id, ImagePath = "NotImage.jpg", Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
        }
    }
}
