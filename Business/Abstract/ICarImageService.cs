using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetImagesByCarId(int CarId);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);

        IResult Add(CarImage carImage, IFormFile formFile);

        IResult Delete(CarImage carImage);

        IResult Update(CarImage carImage, IFormFile formFile);

    }
}
