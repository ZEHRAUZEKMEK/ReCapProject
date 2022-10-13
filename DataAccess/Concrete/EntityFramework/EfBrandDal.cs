using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarContext>, IBrandDal
    {
        //public Brand Get()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Brand> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
