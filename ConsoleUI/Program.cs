using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

            var result2 = carManager.GetById(6);

            if (result2.Success)
            {
                Console.WriteLine(result2.Data.CarDescription,result2.Data.ModelYear);
            }


            //carManager.Update(new Car { CarId = 5, DailyPrice = 2000, ColorId = 5, BrandId = 2, CarDescription = "Dosta asıl bu gider", ModelYear = 2010 });

            var result3 = carManager.GetById(6);

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
