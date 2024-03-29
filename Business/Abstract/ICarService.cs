﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int id);

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<Car>> GetCarsByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarsDetails();

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<CarDetailDto> GetCarDetail(int carId);
        IDataResult<List<CarDetailDto>> GetCarsDtoByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDtoByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDtoByBrandAndColorId(int brandId, int colorId);
    }
}
