using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id=1,BrandId=1,ColorId=1,DailyPrice=90,Description="Mercedes-Benz A200",ModelYear=2016},
                new Car(){Id=2,BrandId=2,ColorId=2,DailyPrice=50,Description="BMW 320d",ModelYear=2013},
                new Car(){Id=3,BrandId=1,ColorId=3,DailyPrice=250,Description="Mercedes-Benz CLS 350 AMG-4Matic",ModelYear=2019},
                new Car(){Id=4,BrandId=3,ColorId=1,DailyPrice=60,Description="Audi A3",ModelYear=2008},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {

            Car carToDelete = _cars.SingleOrDefault(c => c.Id == id);
            _cars.Remove(carToDelete);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;

        }
    }
}
