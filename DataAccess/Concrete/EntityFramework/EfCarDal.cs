using Core.DataAccess.EntityFramework.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MSSQLContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(int carId)
        {
            using (MSSQLContext context = new MSSQLContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.Id equals carImage.CarId into carImagesGroup
                             from carImage in carImagesGroup.DefaultIfEmpty()
                             where car.Id == carId
                             group carImage by new
                             {
                                 car.Id,
                                 car.Description,
                                 brand.BrandName,
                                 color.ColorName,
                                 car.DailyPrice,
                                 car.ModelYear,
                                 brand.BrandId,
                                 color.ColorId
                             } into g
                             select new CarDetailDto
                             {
                                 CarId = g.Key.Id,
                                 Description = g.Key.Description,
                                 BrandName = g.Key.BrandName,
                                 ColorName = g.Key.ColorName,
                                 DailyPrice = g.Key.DailyPrice,
                                 ModelYear = g.Key.ModelYear,
                                 ImagePath = g.Select(c => c.ImagePath).FirstOrDefault(),
                                 BrandId = g.Key.BrandId,
                                 ColorId = g.Key.ColorId
                             };

                return result.FirstOrDefault();
            }
        }


        public List<CarDetailDto> GetCarsDetails()
        {
            using (MSSQLContext context = new MSSQLContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.Id equals carImage.CarId into carImagesGroup
                             from carImage in carImagesGroup.DefaultIfEmpty()
                             group carImage by new
                             {
                                 car.Id,
                                 car.Description,
                                 brand.BrandName,
                                 brand.BrandId, // Ekledik
                                 color.ColorName,
                                 color.ColorId, // Ekledik
                                 car.DailyPrice,
                                 car.ModelYear
                             } into g
                             select new CarDetailDto
                             {
                                 CarId = g.Key.Id,
                                 Description = g.Key.Description,
                                 BrandId = g.Key.BrandId, // Ekledik
                                 BrandName = g.Key.BrandName,
                                 ColorId = g.Key.ColorId, // Ekledik
                                 ColorName = g.Key.ColorName,
                                 DailyPrice = g.Key.DailyPrice,
                                 ModelYear = g.Key.ModelYear,
                                 ImagePath = g.Select(c => c.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDtoByBrandId(int id)
        {
            using (var context = new MSSQLContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             join ci in context.CarImages on ca.Id equals ci.CarId into carImages
                             from ci in carImages.DefaultIfEmpty()
                             where br.BrandId == id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ImagePath = ci.ImagePath
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDtoByColorId(int id)
        {
            using (var context = new MSSQLContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             join ci in context.CarImages on ca.Id equals ci.CarId into carImages
                             from ci in carImages.DefaultIfEmpty()
                             where co.ColorId == id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ImagePath = ci.ImagePath
                             };

                return result.ToList();
            }
        }

    }
}
