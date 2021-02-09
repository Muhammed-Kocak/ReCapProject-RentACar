using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetById(int id);
        List<Car> GetBrandId(int id);
        List<Car> GetColorId(int id);
        List<Car> GetModelYear(decimal minyear,decimal maxyear);
        List<Car> GetDailyPrice(decimal min,decimal max);
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
    }
}
