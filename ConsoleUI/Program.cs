using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 50000, ModelYear = "2015", Description = "a" });

            Console.WriteLine("--- Getting All ---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Price: {0} --- Description: {1} --- CarId: {2} --- BrandId: {3} --- ColorId: {4}",
                    car.DailyPrice, car.Description, car.CarId, car.BrandId, car.ColorId);
            }
            Console.WriteLine("-------------------------");

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("-------------------------");

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
