using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if(rental.ReturnDate != DateTime.MinValue)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.ItemAdded);
            }
            return new ErrorResult(Message.ItemNotAdded);
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.ItemRemoved);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.ItemListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Message.ItemListed);
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id), Message.ItemListed);
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == id), Message.ItemListed);
        }

        public IResult Update(Rental rental)
        {
            if(rental.RentDate != DateTime.MinValue)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Message.ItemUpdated);
            }
            return new ErrorResult(Message.ItemNotUpdated);
        }
    }
}
