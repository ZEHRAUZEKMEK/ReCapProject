using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entity.Concrete;
using System;

namespace ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //CarAdd();
            //CarsUpdate();
            //CarDelete();
            //CarGetAll();
            //CarGetById();
            //CarGetByColorId();
            //CarGetByBrandId();
            //GetByBrandId();
            //BrandGetAll();
            //BrandAdd();
            //BrandsUpdate();
            //BrandDelete();
            //ColorAdd();
            //ColorDelete();
            //ColorsUpdate();
            //ColorGetAll();
            //CustomerAdd();
            //CustomerDelete();
            //CustomersUpdate();
            //CustomerGetAll();
            //UserAdd();
            //UserDelete();
            //UsersUpdate();
            //UserGetAll();
            //CarGetAllById();
            //CarGetByUnitPrice();
            //CarGetByDescription();
            //CustomerGetByUserId();
            //UserGetById();
            //RentalGetById();
            //RentalGetAll();
            //RentalAdd();
            //RentalsUpdate();
            //RentalDelete();
        }

        private static void RentalDelete()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rental = new Rental { Id = 22 };
            var result = rentalManager.Delete(rental);
            Console.WriteLine(result.Message);
        }

        private static void RentalsUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rental = new Rental { Id = 15, CustomerId = 14, CarId = 18 };
            var result = rentalManager.Update(rental);
            Console.WriteLine(result.Message);
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rental = new Rental { Id = 15, CustomerId = 14, CarId = 18 };
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.CustomerId + " , " + rental.Id + " , " + rental.RentDate + " , " + rental.ReturnDate);
            }
        }

        private static void RentalGetById()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetById(6);
            foreach (var rental in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserGetById()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetById(8);
            foreach (var user in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerGetByUserId()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetByUserId(6);
            foreach (var customer in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetByDescription()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByDescription("Audi" + "Jeep");
            foreach (var car in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetByUnitPrice()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByUnitPrice(12000, 25000);
            foreach (var car in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAllById()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAllById(12);
            foreach (var car in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserGetAll()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.Id + " , " + user.FirstName + " , " + user.LastName);
            }
        }

        private static void UsersUpdate()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = new User { Id = 18, FirstName = "Fatma", LastName = "Z", Email = "laksmx@gmail.com" };
            var result = userManager.Update(user);
            Console.WriteLine(result.Message);
        }

        private static void UserDelete()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = new User { FirstName = "Ali" };
            var result = userManager.Delete(user);
            Console.WriteLine(result.Message);
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = new User { Id = 18, FirstName = "Zehra", LastName = "Uzk", Email = "zehra.uzekmke@gmail.com" };
            var result = userManager.Add(user);
            Console.WriteLine(result.Message);
        }

        private static void CustomerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.UserId + " , " + customer.CompanyName);
            }
        }

        private static void CustomersUpdate()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customer = new Customer { UserId = 15, CompanyName = "Zehra" };
            var result = customerManager.Update(customer);
            Console.WriteLine(result.Message);
        }

        private static void CustomerDelete()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customer = new Customer { UserId = 5 };
            var result = customerManager.Delete(customer);
            Console.WriteLine(result.Message);
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customer = new Customer { UserId = 15, CompanyName = "x" };
            var result = customerManager.Add(customer);
            Console.WriteLine(result.Message);
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void ColorsUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var color = new Color { Id = 19, Name = "Şampanya" };
            var result = colorManager.Update(color);
            Console.WriteLine(result.Message);
        }

        private static void ColorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var color = new Color { Name = "Pembe" };
            var result = colorManager.Delete(color);
            Console.WriteLine(result.Message);
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var color = new Color { Id=15, Name = "Mor" };
            var result = colorManager.Add(color);
            Console.WriteLine(result.Message);
        }

        private static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = new Brand { Id = 13 };
            var result = brandManager.Delete(brand);
            Console.WriteLine(result.Message);
        }

        private static void BrandsUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = new Brand { Id = 32, Name = "Cherry" };
            var result = brandManager.Update(brand);
            Console.WriteLine(result.Message);
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = new Brand { Id = 32, Name = "Cherry" };
            var result = brandManager.Add(brand);
            Console.WriteLine(result.Message);
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetByBrandId()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brand = brandManager.GetByBrandId(12);
            var data = brand.Data;
            Console.WriteLine(data.Name);
        }

        private static void CarGetByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetByBrandId(15);
            foreach (var car in result.Data)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetByColorId(3);
            foreach (var car in result.Data)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetById(3);
            foreach (var car in result.Message)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandId + " " + car.Description);
            }
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car = new Car { Id = 5 };
            var result = carManager.Delete(car);
            Console.WriteLine(result.Message);
        }

        private static void CarsUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car = new Car { BrandId = 15, ColorId = 3, DailyPrice = 2500, Id = 9, Description = "Renault" };
            var result = carManager.Update(car);
            Console.WriteLine(result.Message);
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car = new Car { BrandId = 15, ColorId = 3, DailyPrice=2500, Id=9, Description= "Renault" };
            var result = carManager.Add(car);
            Console.WriteLine(result.Message);
        }
        
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result=carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Name+" / "+car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

           
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var colors = colorManager.GetAll();

            foreach (var color in colors.Data)
            {
                Console.WriteLine(color.Id);
            }

           
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var brands = brandManager.GetAll(); 

            foreach (var brand in brands.Data)
            {
                Console.WriteLine(brand.Id);
            }
        }
    }
}
