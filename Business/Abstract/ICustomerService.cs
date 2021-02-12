using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        DataResult<List<Customer>> GetAll();
        DataResult<Customer> GetById(int id);
        Result Add(Customer customer);
        Result Delete(Customer customer);
        Result Update(Customer customer);
    }
}
