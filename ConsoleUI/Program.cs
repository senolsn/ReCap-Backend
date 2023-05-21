using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car() { Id = 5, BrandId = 5, ColorId = 5, Description = "Seat Leon 1.4 TSI", DailyPrice = 75, ModelYear = 2020 });
            Console.WriteLine("Add Methodu Çalıştırıldı");
            Console.WriteLine("------------------------");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Delete Methodu Çalıştırıldı");
            Console.WriteLine("------------------------");

            carManager.Delete(new Car() { Id = 5, });
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Update Methodu Çalıştı BMW 320d M3 olarak değiştirildi");
            Console.WriteLine("------------------------");

            carManager.Update(new Car() { Id = 2,Description="BMW M3 " });
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("GetById Methodu Çalıştırıldı");
            Console.WriteLine("------------------------");

            Console.WriteLine(carManager.GetById(3).Description);
            Console.WriteLine("------------------------");




        }
    }
}