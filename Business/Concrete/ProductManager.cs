using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService<Car>
    {
        IProductDal<Car> _productDal;

        public ProductManager(IProductDal<Car> productDal)
        {
            _productDal = productDal;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
