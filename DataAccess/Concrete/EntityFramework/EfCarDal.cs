using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        
        public List<CarDetailDto> GetCarByBrand(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 CarId = car.CarId,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId
                             };
                return result.Where(c => c.BrandId == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarByColor(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 CarId = car.CarId,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId
                             };
                return result.Where(c => c.ColorId == id).ToList();
            }
        }
        public CarDetailDto GetCarDetail(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Cars.Where(p => p.CarId == carId)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = d.BrandName,
                                 CarId = p.CarId,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 Status = context.Rentals.Any(p => p.CarId == p.CarId && p.ReturnDate == null),
                                 ModelYear = p.ModelYear,
                                 BrandId = d.BrandId,
                                 ColorId = c.ColorId
                             };

                return result.SingleOrDefault();
            }
        }
        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = d.BrandName,
                                 CarId = p.CarId,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 Status = !context.Rentals.Any(r => r.CarId == p.CarId) || !context.Rentals.Any(r => r.CarId == p.CarId && (r.ReturnDate == null || (r.ReturnDate.HasValue && r.ReturnDate > DateTime.Now))),
                                 ModelYear = p.ModelYear,
                                 BrandId = d.BrandId,
                                 ColorId = c.ColorId
                             };
                return result.ToList();
            }
        }
    }
}
