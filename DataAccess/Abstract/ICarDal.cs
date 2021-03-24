using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails();
        CarDetailDto GetCarDetail(int carId);
        List<CarDetailDto> GetCarByColor(int id);
        List<CarDetailDto> GetCarByBrand(int id);
    }
}
