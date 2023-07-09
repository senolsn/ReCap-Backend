using Core.DataAccess.EntityFramework.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,MSSQLContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails()
        {
            using (var context = new MSSQLContext())
            {
                var result = from r in context.Rentals
                             join
                              cs in context.Customers
                             on
                             r.CustomerId equals cs.Id
                             join u in context.Users
                             on
                             cs.UserId equals u.Id
                             join c in context.Cars
                             on
                             r.CarId equals c.Id
                             join clr in context.Colors
                             on
                             c.ColorId equals clr.ColorId
                             join b in context.Brands
                             on
                             c.BrandId equals b.BrandId

                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarDescription = c.Description,
                                 CustomerName = $"{u.FirstName} {u.LastName}".ToUpper(),
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }

        }
    }
}
