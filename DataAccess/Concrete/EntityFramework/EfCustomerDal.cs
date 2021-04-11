using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users on customer.UserId equals user.UserId
                             select new CustomerDetailDto()
                             {
                                 CustomerId = customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email
                             };
                return result.ToList();
            }
        }
    }
}
