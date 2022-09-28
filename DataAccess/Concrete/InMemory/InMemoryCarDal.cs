using Core.DataAccess;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=3000, ModelYear="2020", Description="BMW" },
                new Car{Id=2, BrandId=2, ColorId=2, DailyPrice=5000, ModelYear="2021", Description="Audi" },
                new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=7000, ModelYear="2021", Description="Audi" },
                new Car{Id=4, BrandId=3, ColorId=2, DailyPrice=10000, ModelYear="2022", Description="Porsche" },
                new Car{Id=5, BrandId=3, ColorId=2, DailyPrice=15000, ModelYear="2022", Description="Porsche" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(car => car.Id == car.Id);
            _cars.Remove(carToDelete);

        }
             
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> Get()
        {
            throw new NotImplementedException();
        }

        public Car Get(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
               

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(car => car.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

       
    }
}
