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
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManagerTest();
            //ColorManagerTest();
            //UserManagerTest();
            //ResultsTest();
            //ErrorTest();
            //CustomerManagerTest();
            //RentalManagerTest();

            //CarImageManager carImageService = new CarImageManager(new EfCarImageDal());
            //var result = carImageService.Add(new CarImage { ImageId = 2, CarId = 3, ImagePath = "asdasd", Date = new DateTime(2020, 10, 16) });

            //var s = Path.GetTempFileName();
            //Console.WriteLine(s);
            //Stream stream = new FileStream();



        }

        private static void RentalManagerTest()
        {
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 3, CustomerId = 1, RentDate = new DateTime(2019, 5, 10) });
            //rentalManager.Update(new Rental { CarId=3, new DateTime(2019, 6, 10) });
        }

        private static void CustomerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserId = 1002, CompanyName = "Ev" });

            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.UserId + "---" + customer.CompanyName);
                }
            }
        }

        private static void ErrorTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Add(new Car { DailyPrice = 7000, BrandId = 3, ColorId = 1, ModelYear = "1996", Description = "dsfsdsfsdf" });

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

            var result2 = carManager.GetCarsDetails(); // 'var' ile de 'IDataResult' ile de tanımlanabilr. Aynı şeydir
            if (result2.Success)
            {
                foreach (var car in result2.Data)
                {
                    Console.WriteLine("Car Description: {0} --- Car Brand: {1} --- Car Color: {2} --- Car Daily Price: {3}"
                        , car.Description, car.BrandName, car.ColorName, car.DailyPrice);
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
            var result = colorManager.GetAll();
            Console.WriteLine(result.Message);
            foreach (var color in result.Data)
            {
                Console.WriteLine("ColorId: {0} --- Color Name: {1}", color.ColorId, color.ColorName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 50000, ModelYear = "2015", Description = "a" });

            Console.WriteLine("--- Getting All ---");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Price: {0} --- Description: {1} --- CarId: {2} --- BrandId: {3} --- ColorId: {4}",
                    car.DailyPrice, car.Description, car.Id, car.BrandId, car.ColorId);
            }
            Console.WriteLine("-------------------------");

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("-------------------------");

            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
