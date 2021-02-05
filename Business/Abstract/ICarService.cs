using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService<T>
    {
        List<T> GetById(int id);
        List<T> GetBrandId(int id);
        List<T> GetColorId(int id);
        List<T> GetModelYear(decimal minyear,decimal maxyear);
        List<T> GetDailyPrice(decimal min,decimal max);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
