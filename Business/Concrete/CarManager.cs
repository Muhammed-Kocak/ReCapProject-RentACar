using Business.Abstract;
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
        public void Add(Car entity)
        {
            if (entity.DailyPrice > 0)
            {
                _carDal.Add(entity);
                Console.WriteLine("Araba Başarıyla Sisteme Eklendi!");
            }
            else
            {
                Console.WriteLine("Üzgünüz. Günlük Fiyatı 0 Olamaz");
            }
        }
        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
            Console.WriteLine("Araba Başarıyla Silindi.");
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(c => c.CarId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => min <= c.DailyPrice && c.DailyPrice <= max);
        }

        public List<Car> GetModelYear(decimal minyear, decimal maxyear)
        {
            return _carDal.GetAll(c => minyear <= c.ModelYear && c.ModelYear <= maxyear);
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
