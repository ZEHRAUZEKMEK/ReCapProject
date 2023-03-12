using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationResults.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{ 
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            //_carDal.Update(car);
            //_carDal.Add(car);
            //return new SuccessResult(Messages.CarsUpdated);
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarsUpdated);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        
        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetByBrandId(car => car.Id == brandId));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
           
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(
                _carDal.GetCarDetails().SingleOrDefault(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
               _carDal.GetCarDetails().Where(c => c.BrandId == brandId).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
               _carDal.GetCarDetails()
               .Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
                _carDal.GetCarDetails().Where(c => c.ColorId == colorId).ToList());
        }
    }
}
