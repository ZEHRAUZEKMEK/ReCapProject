using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public Car Get(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from d in context.Cars
                             join c in context.Brands
                             on d.BrandId equals c.Id
                             select new CarDetailDto { BrandId = c.Id, Name = c.Name };
                return result.ToList();
            }
            
        }

        List<Car> ICarDal.Get()
        {
            throw new NotImplementedException();
        }
    }
}
