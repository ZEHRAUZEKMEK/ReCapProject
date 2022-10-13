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
        //public Car Get(Func<object, bool> value)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> Get()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join d in context.Brands on c.BrandId equals d.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailDto { Name = c.Description, ColorId=co.Id, BrandId=d.Id };
                return result.ToList();
            }
            
        }

      
    }
}
