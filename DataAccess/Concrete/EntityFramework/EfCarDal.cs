using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var addedEntity = rentACarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentACarContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var deletedEntity = rentACarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACarContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return rentACarContext.Set<Car>().SingleOrDefault();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return filter == null ? rentACarContext.Set<Car>().ToList() : rentACarContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var updateEntity = rentACarContext.Entry(entity);
                updateEntity.State = EntityState.Modified;
                rentACarContext.SaveChanges();
            }
        }
    }
}
