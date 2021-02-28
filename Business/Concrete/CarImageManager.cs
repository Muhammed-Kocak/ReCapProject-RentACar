using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImagesDal carImagesDal, ICarService carService)
        {
            _carImageDal = carImagesDal;
            _carService = carService;
        }

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

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.CarId == entity.CarId);
            File.Delete(@"wwwroot\images\" + imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

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
            if (!_carService.GetById(carId).Success)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.GetErrorCarDetails);
            }
            return new SuccessDataResult<List<CarImage>>();
        }
    }
}
