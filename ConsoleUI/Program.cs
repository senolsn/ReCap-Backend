using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarGetById();
            //CarDtoTest();

            //AddUserMethod();
            //ListUserMethod();

            //AddCustomer();
            //ListCustomer();

            //AddRental();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Update(new Rental() { Id=4,ReturnDate = DateTime.Now,CarId=1,CustomerId=2,RentDate=DateTime.Now});
            Console.WriteLine(rentalManager.GetById(4).Data.ReturnDate);

        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental() { CarId = 1, CustomerId = 2, RentDate = DateTime.Now });
        }

        private static void ListCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer() { UserId = 1, CompanyName = "Yildiz Hukuk" });
            customerManager.Add(new Customer() { UserId = 3, CompanyName = "Sehriyar Restaurant" });
        }

        private static void ListUserMethod()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static UserManager AddUserMethod()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User() { FirstName = "Senol", LastName = "Sen", Email = "senol@mail.com", Password = "123" });
            userManager.Add(new User() { FirstName = "Melike", LastName = "Yildiz", Email = "melike@mail.com", Password = "123" });
            userManager.Add(new User() { FirstName = "Cemal", LastName = "Furkan", Email = "cefuok@mail.com", Password = "123" });
            userManager.Add(new User() { FirstName = "Emrecan", LastName = "Ay", Email = "emre@mail.com", Password = "123" });
            userManager.Add(new User() { FirstName = "Saban", LastName = "Donmez", Email = "saban@mail.com", Password = "123" });
            return userManager;
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var cars in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araç : {0} Marka : {1} Renk : {2}", cars.Description, cars.BrandName, cars.ColorName);
            }

            Console.WriteLine(carManager.GetCarDetails().Success);
        }

        //private static void CarGetById()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Console.WriteLine(carManager.GetById(1).Description);
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.Description);
        //    }
        //}
    }
}