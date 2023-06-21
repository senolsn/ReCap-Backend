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

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var cars in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araç : {0} Marka : {1} Renk : {2}",cars.Description, cars.BrandName,cars.ColorName);
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