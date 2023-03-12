using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            Customer customer1 = new Customer();

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void DetailsDemo()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.BrandName + " / " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
