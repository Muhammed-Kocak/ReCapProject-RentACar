using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService<T>
    {
        List<T> GetById();
        List<T> GetAll();
        void Add();
        void Update();
        void Delete();
    }
}
