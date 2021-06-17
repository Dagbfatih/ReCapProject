using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails();

        CarDetailDto GetCarDetails(int carId);

        List<CarDetailDto> GetCarsDetailsByBrandId(int brandId);

        List<CarDetailDto> GetCarsDetailsByColorId(int brandId);

        List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId);
    }
}
