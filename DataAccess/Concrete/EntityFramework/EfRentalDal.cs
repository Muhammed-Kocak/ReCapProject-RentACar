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
    public class EfRentalDal : EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join customer in context.Customers
                             on r.CustomerId equals customer.CustomerId
                             join user in context.Users
                             on customer.UserId equals user.UserId
                             select new RentalDetailDto()
                             {
                                 RentalDtoId = r.RentalId,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();
            }
        }
    }
}
