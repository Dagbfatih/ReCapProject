using Business.Concrete;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            //ColorManagerTest();
            //ResultsTest();
            //ErrorTest();

        }

        private static void ErrorTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Add(new Car { DailyPrice = 500, BrandId = 3, ColorId = 1, ModelYear = "1995", Description = "a" });

            Console.WriteLine(result.Message);
        }

        private static void ResultsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
                Console.WriteLine("-----------------------");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            var result2 = carManager.GetCarDetails(); // 'var' ile de 'IDataResult' ile de tanımlanabilr. Aynı şeydir
            if (result2.Success)
            {
                foreach (var car in result2.Data)
                {
                    Console.WriteLine("Car Description: {0} --- Car Brand: {1} --- Car Color: {2} --- Car Daily Price: {3}"
                        , car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId: {0} --- Color Name: {1}", color.ColorId, color.ColorName);
            }
        }

        private static void CarManagerTest()
        {
            //CarManager carManager = new CarManager(new EfCarDal());

            ////carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 50000, ModelYear = "2015", Description = "a" });

            //Console.WriteLine("--- Getting All ---");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Price: {0} --- Description: {1} --- CarId: {2} --- BrandId: {3} --- ColorId: {4}",
            //        car.DailyPrice, car.Description, car.CarId, car.BrandId, car.ColorId);
            //}
            //Console.WriteLine("-------------------------");

            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("-------------------------");

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}
        }
    }
}
