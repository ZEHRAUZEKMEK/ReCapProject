using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationResults.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        private string ImagesPath = "wwwroot\\Uploads\\CarImages\\";

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public static void CreateFolder()
        {
            if (!Directory.Exists(@"CarImages\"))
                Directory.CreateDirectory(@"CarImages\");

            if (!Directory.Exists("CarImages" + @"Porsche\"))
                Directory.CreateDirectory(@"Porsche\");

            if (!Directory.Exists("CarImages" + @"Opel\"))
                Directory.CreateDirectory(@"Opel\");

            if (!Directory.Exists("CarImages" + @"Volvo\"))
                Directory.CreateDirectory(@"Volvo\");

            if (!Directory.Exists("CarImages" + @"Mercedes-Benz\"))
                Directory.CreateDirectory(@"Mercedes-Benz\");

            if (!Directory.Exists("CarImages" + @"Volkswagen\"))
                Directory.CreateDirectory(@"Volkswagen\");

            if (!Directory.Exists("CarImages" + @"Jeep\"))
                Directory.CreateDirectory(@"Jeep\");

            if (!File.Exists("CarImages"+@"RunHistory"+".jpeg"))
            {
                FileStream fs = File.Create("CarImages" + @"RunHistory_" + ".jpeg");
                fs.Close();
            }

            if (!File.Exists("CarImages" + @"RunHistory" + ".jpeg"))
            {
                FileStream fs = File.Create("CarImages" + @"RunList_" + ".jpeg");
                fs.Close();
            }
        }

            
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            //return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
           return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == carId));
        }

       
        public IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath="DefaultImage.jpeg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

      
        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(cI => cI.CarId == carId).Count;
            if (result >5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        IDataResult<List<CarImage>> ICarImageService.GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        IDataResult<CarImage> ICarImageService.GetByImageId(int ImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == ImageId));
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, ImagesPath);
            //Path.GetPathRoot(@"C:\CarImages\"));

            carImage.Date = DateTime.Now;


            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(ImagesPath + carImage.ImagePath);
            //(Path.GetPathRoot(@"C:\CarImages\") + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, ImagesPath + carImage.ImagePath, ImagesPath);
            //(file, Path.GetPathRoot(@"C:\CarImages\"), carImage.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImagesUpdated);
        }
    }
}
