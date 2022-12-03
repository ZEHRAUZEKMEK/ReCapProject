using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetDefaultImage(int carId);
        IResult Add(List<IFormFile> formFile, CarImage carImage);
        IResult Update(List<IFormFile> file, CarImage carImage);

        IResult Delete(CarImage carImage);
      
    }
}
