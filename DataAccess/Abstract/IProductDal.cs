using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal<T>
    {
        List<T> GetById(T product);
        List<T> GetAll();
        void Add(T product);
        void Update(T product);
        void Delete(T product);
    }
}
