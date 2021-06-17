using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, SqlContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails()
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CarId = car.Id,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 Description=car.Description,
                                 ModelYear=car.ModelYear,
                                 CompanyName = customer.CompanyName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };

                return result.ToList();
            }
        }

        public RentalDetailDto GetRentalDetails(int id)
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from rental in context.Rentals.Where(r => r.Id == id)
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join brand in context.Brands
                             on rental.BrandId equals brand.BrandId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
