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
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
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



        [SecuredOperation("carImage.add, admin")]
        [ValidationAspect(typeof(CarImageValidator))]
       
        public IResult Add(List<IFormFile> formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(formFile, Path.GetPathRoot(@"C:\CarImages\"));
               //Burada kaldım.
            carImage.Date = DateTime.Now;


            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(Path.GetPathRoot(@"C:\CarImages\") + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

       
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
           return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListedByCarId);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(car => car.Id==id));
        }

        public IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = Path.GetFileName(@"C:\CarImages\") });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(List<IFormFile> file, CarImage carImage)
        {
           carImage.ImagePath=_fileHelper.Update(file, Path.GetPathRoot(@"C:\CarImages\"), carImage.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImagesUpdated);
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
        
    }
}
