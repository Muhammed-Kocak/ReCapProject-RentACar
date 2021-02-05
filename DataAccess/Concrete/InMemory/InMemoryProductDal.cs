using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _products;
        public InMemoryProductDal()
        {
            _products = new List<Car>
            {
                new Car{BrandId =1 , ColorId = 4, ModelYear = 1999 ,CarDescription = "Şahin Dosta Gider",DailyPrice = 40000},
                new Car{BrandId =2 , ColorId = 1, ModelYear = 2019 ,CarDescription = "Şahin Dosta Gitmez",DailyPrice = 25000},
                new Car{BrandId =2 , ColorId = 5, ModelYear = 2010 ,CarDescription = "Şahin Dosta Gidermiş Gibi Olan",DailyPrice = 12500},
                new Car{BrandId =1 , ColorId = 7, ModelYear = 2013 ,CarDescription = "Şahin Hurda",DailyPrice = 5000}
            };
        }
        public void Add(Car product)
        {
            _products.Add(product);
        }

        public void Delete(Car product)
        {
            Car carRemove = _products.SingleOrDefault(c => c.CarId == product.CarId);
            _products.Remove(carRemove);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _products;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car product)
        {
            return _products.Where(c => c.CarId == product.CarId).ToList();  
        }

        public void Update(Car product)
        {
            Car carRemove = _products.SingleOrDefault(c => c.CarId == product.CarId);
            carRemove.CarDescription = product.CarDescription;
            carRemove.DailyPrice = product.DailyPrice;
            carRemove.ColorId = product.ColorId;
            carRemove.BrandId = product.BrandId;
            carRemove.ModelYear = product.ModelYear;
        }
    }
}
