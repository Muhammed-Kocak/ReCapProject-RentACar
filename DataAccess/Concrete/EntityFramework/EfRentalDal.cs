using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

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
        public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join customer in context.Customers
                        on rental.CustomerId equals customer.CustomerId
                    join user in context.Users
                         on customer.UserId equals user.UserId
                    join car in context.Cars
                         on rental.CarId equals car.CarId
                    join brand in context.Brands
                         on car.BrandId equals brand.BrandId
                    join color in context.Colors
                         on car.ColorId equals color.ColorId
                    select new RentalDetailDto
                    {
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        RentalDtoId = rental.RentalId,
                        BrandName = brand.BrandName,
                        CarDesctiption = car.Description,
                        ColorName = color.ColorName,
                        CompanyName = customer.CompanyName,
                        DailyPrice = car.DailyPrice,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ModelYear = car.ModelYear
                    };

                return result.ToList();
            }
        }
    }
}
