using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlContext>, ICarDal
    {
        public CarDetailDto GetCarDetails(int carId)
        {
            using (SqlContext context = new SqlContext())
            {
                var carDetails = from c in context.Cars
                                 where c.Id == carId
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 orderby c.DailyPrice
                                 select new CarDetailDto
                                 {
                                     CarId = c.Id,
                                     Description = c.Description,
                                     BrandId = b.BrandId,
                                     BrandName = b.BrandName,
                                     ColorId = co.ColorId,
                                     ModelYear = c.ModelYear,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice
                                 };
                return carDetails.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (SqlContext context = new SqlContext())
            {
                var carDetails = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 where c.BrandId == brandId
                                 where c.ColorId == colorId
                                 orderby c.DailyPrice
                                 select new CarDetailDto
                                 {
                                     CarId = c.Id,
                                     Description = c.Description,
                                     BrandId = b.BrandId,
                                     BrandName = b.BrandName,
                                     ColorId = co.ColorId,
                                     ModelYear = c.ModelYear,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice
                                 };
                return carDetails.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            using (SqlContext context = new SqlContext())
            {
                var carDetails = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 orderby c.DailyPrice
                                 select new CarDetailDto
                                 {
                                     CarId = c.Id,
                                     Description = c.Description,
                                     BrandId = b.BrandId,
                                     BrandName = b.BrandName,
                                     ColorId = co.ColorId,
                                     ModelYear = c.ModelYear,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice
                                 };
                return carDetails.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId)
        {
            using (SqlContext context = new SqlContext())
            {
                var carDetails = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 where b.BrandId == brandId
                                 orderby c.DailyPrice
                                 select new CarDetailDto
                                 {
                                     CarId = c.Id,
                                     Description = c.Description,
                                     BrandId = b.BrandId,
                                     BrandName = b.BrandName,
                                     ColorId = co.ColorId,
                                     ModelYear = c.ModelYear,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice
                                 };
                return carDetails.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int colorId)
        {
            using (SqlContext context = new SqlContext())
            {
                var carDetails = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 where c.ColorId == colorId
                                 orderby c.DailyPrice
                                 select new CarDetailDto
                                 {
                                     CarId = c.Id,
                                     Description = c.Description,
                                     BrandId = b.BrandId,
                                     BrandName = b.BrandName,
                                     ColorId = co.ColorId,
                                     ModelYear = c.ModelYear,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice
                                 };
                return carDetails.ToList();
            }
        }
    }
}
