﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetById(int carId);

        List<Car> GetByBrandId(int brandId);

        void Add(Car car);

        void Delete(Car car);

        void Update(Car car);
    }
}
