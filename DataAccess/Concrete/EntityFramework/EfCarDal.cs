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
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join d in context.Brands on c.BrandId equals d.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailDto {
                                 Id = c.Id,
                                 BrandId = d.Id,
                                 ColorId = co.Id,
                                 BrandName = d.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
            
        }

      
    }
}
