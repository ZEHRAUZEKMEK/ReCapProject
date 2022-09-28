using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetAllById(int id);
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetByDescription(string description);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car car);
        IDataResult<Car> GetById(int id);

    }
}
