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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var addedEntity = rentACarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentACarContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var deletedEntity = rentACarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACarContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return rentACarContext.Set<Color>().SingleOrDefault();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                return filter == null ? rentACarContext.Set<Color>().ToList() : rentACarContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
