using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerDal _customerDal;
        public RentalManager(IRentalDal rentalDal, ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _customerDal = customerDal;
        }
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarAvailable(rental));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            var result = _rentalDal.Get(r => r.CarId == carId);
            if (result == null)
            {
                return new ErrorDataResult<Rental>(result, "error");
            }

            return new SuccessDataResult<Rental>(result, "successfully");

        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails());
        }

        public IDataResult<RentalDetailDto> GetRentalDetailsById(int carId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetails(carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }



        private IResult CheckCarAvailable(Rental rental)
        {
            var result =
                _rentalDal.Get(r => (r.CarId == rental.CarId && r.ReturnDate == null)
            || (r.RentDate >= rental.RentDate && r.ReturnDate >= rental.RentDate));

            if (result != null)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }

            return new SuccessResult();
        }
    }
}
