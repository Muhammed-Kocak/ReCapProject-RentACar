using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
            CarDetailTest();
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(@$"{car.CarId}'id sahibi olan araç {car.BrandName} markalı ve {car.ColorName} renge sahip. Şu anki satış fiyatı: {car.DailyPrice}");
            }
            Console.WriteLine("--CAR DETAİL--");
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("--COLOR--");
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }
            Console.WriteLine("--CAR--");
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine("--BRAND--");
        }
    }
}
