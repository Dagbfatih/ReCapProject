using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);

        IDataResult<CarDetailDto> GetDetails(int id);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorAndBrand(int brandId, int colorId);

        IDataResult<List<CarDetailDto>> GetCarsDetails();

        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);

        IResult TransactionalOperation(Car car);
    }
}
