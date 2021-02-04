using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){CarId=1, BrandId=2, ColorId=3, DailyPrice=500, ModelYear="2000", Description="BMW"},
                new Car(){CarId=2, BrandId=1, ColorId=1, DailyPrice=1000, ModelYear="2010", Description="Mercedes"},
                new Car(){CarId=3, BrandId=1, ColorId=1, DailyPrice=200, ModelYear="1990", Description="Toros"},
                new Car(){CarId=4, BrandId=2, ColorId=2, DailyPrice=2000, ModelYear="2013", Description="Lamborghini"},
                new Car(){CarId=5, BrandId=1, ColorId=3, DailyPrice=5000, ModelYear="2017", Description="Toyota"}
            };
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Func<Car, bool> filter = null)
        {
                return filter == null ? _cars : _cars.Where(filter).ToList();
        }

        public void Update(Car entity)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
            carToUpdate.ModelYear = entity.ModelYear;
        }
    }
}
