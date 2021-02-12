using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
            //CarDetailTest();
            //UserManagerTest();
            //CustomerManagerTest();
            //RentalManagerTest();
        }

        private static void RentalManagerTest()
        {
            CarDetailDto carDetailDto = new CarDetailDto();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = new DateTime(2020, 06, 23) });

            //rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, RentDate = new DateTime(2021, 11, 26) });

            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine($@"{rental.CustomerId}'idli müşterimiz {rental.CarId}'idli arabayı {rental.RentDate} tarihinde kiralamıştır ");
                    if (rental.ReturnDate != null)
                    {
                        Console.WriteLine($@"{rental.ReturnDate} tarihinde                                          teslim etmiştir.");
                    }
                }
            }

            Console.WriteLine("--Update--");

            rentalManager.Update(new Rental { RentalId = 4,CarId =2,CustomerId =1,RentDate = new DateTime(2020,06,23), ReturnDate = new DateTime(2020, 07, 01) });

            var result2 = rentalManager.GetAll();
            if (result2.Success)
            {
                foreach (var rental in result2.Data)
                {
                    Console.WriteLine($@"{rental.CustomerId}'idli müşterimiz {rental.CarId}'idli arabayı {rental.RentDate} tarihinde kiralamıştır ");
                    if (rental.ReturnDate != null)
                    {
                        Console.WriteLine($@"{rental.ReturnDate} tarihinde                                          teslim etmiştir.");
                    }
                }
            }
        }

        private static void CustomerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { UserId = 1, CompanyName = "Epic Games" });
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Steam" });
            customerManager.Add(new Customer { UserId = 9, CompanyName = "Valve" });

            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine($@"{customer.CompanyName}");
                }
            }

            customerManager.Delete(new Customer { CustomerId = 2 });

            var result2 = customerManager.GetAll();
            if (result2.Success)
            {
                foreach (var customer in result2.Data)
                {
                    Console.WriteLine($@"{customer.CompanyName}");
                }
            }
        }

        private static void UserManagerTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Emre", LastName = "Altuğ", EMail = "emre.altug@hotmail.com", Password = "1234altug56789" });
            userManager.Add(new User { FirstName = "Gülhan", LastName = "Altundaşar", EMail = "gülhan.altundaşar26@hotmail.com", Password = "1234altun56789" });
            userManager.Add(new User { FirstName = "Menekşe", LastName = "Çiçek", EMail = "menekse.cicek@hotmail.com", Password = "1234cicek56789" });
            userManager.Add(new User { FirstName = "Aşkın", LastName = "Sever", EMail = "askin.sever@hotmail.com", Password = "1234sever56789" });

            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine($@"{user.FirstName} \ {user.LastName} \ {user.EMail}");
                }
            }

            userManager.Delete(new User { UserId = 11 });
            userManager.Delete(new User { UserId = 12 });

            var result2 = userManager.GetAll();
            if (result2.Success)
            {
                foreach (var user in result2.Data)
                {
                    Console.WriteLine($@"{user.FirstName} \ {user.LastName} \ {user.EMail}");
                }
            }
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine(@$"{car.CarId}'id sahibi olan araç {car.BrandName} markalı ve {car.ColorName} renge sahip. Şu anki satış fiyatı: {car.DailyPrice}");
                }
            }



            Console.WriteLine("--CAR DETAİL--");
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            Console.WriteLine("--COLOR--");

            //colorManager.Add(new Color { ColorName = "Purple" });

            var result2 = colorManager.GetById(6);

            if (result2.Success)
            {
                Console.WriteLine(result2.Data);
            }

            colorManager.Update(new Color { ColorId = 6, ColorName = "Mor" });
        }
        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ModelYear);
                }
            }
            Console.WriteLine("--CAR--");

            //carManager.Add(new Car { BrandId = 1, ColorId = 6, DailyPrice = 1000, ModelYear = 1990, CarDescription = "Dosta nasıl gider" });

            var result2 = carManager.GetById(2);

            if (result2.Success)
            {
                Console.WriteLine(result2.Data.CarDescription, result2.Data.ModelYear);
            }


            //carManager.Update(new Car { CarId = 5, DailyPrice = 2000, ColorId = 5, BrandId = 2, CarDescription = "Dosta asıl bu gider", ModelYear = 2010 });

            var result3 = carManager.GetById(2);

            if (result3.Success)
            {
                Console.WriteLine(result3.Data.CarDescription, result3.Data.ModelYear);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            Console.WriteLine("--BRAND--");

            //brandManager.Add(new Brand { BrandName = "Suzuki" });

            var result2 = brandManager.GetById(6);

            if (result2.Success)
            {
                Console.WriteLine(result2.Data.BrandName);
            }

            //brandManager.Update(new Brand { BrandId = 7, BrandName = "SUZUKİ" });

            var result3 = brandManager.GetById(6);

            if (result3.Success)
            {
                Console.WriteLine(result3.Data.BrandId.ToString(), result3.Data.BrandName);
            }
        }
    }
}
