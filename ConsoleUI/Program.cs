using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car() { CarId = 6, BrandId = 2, ColorId = 1, DailyPrice = 10000, Description = "Ford", ModelYear = "2020" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Delete(new Car { CarId = 2 });

            Console.WriteLine("----------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("----------------");
            foreach (var car in carManager.GetByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
