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
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.UserId equals customer.UserId
                             select new CustomerDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
