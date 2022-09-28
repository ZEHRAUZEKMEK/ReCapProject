using Core.DataAccess;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<Car> Get();
        Car Get(Func<object, bool> value);
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();

    }
}
