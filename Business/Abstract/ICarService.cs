using Core.Utilities;
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
        IDataResult<Car> GetBrandId(int id);
        IDataResult<Car> GetColorId(int id);
        IDataResult<List<Car>> GetModelYear(decimal minyear,decimal maxyear);
        IDataResult<List<Car>> GetDailyPrice(decimal min,decimal max);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarDetails();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
    }
}
