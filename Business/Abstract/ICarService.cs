using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetModelYear(decimal minyear,decimal maxyear);
        IDataResult<List<Car>> GetDailyPrice(decimal min,decimal max);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrand(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColor(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId);
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
    }
}
