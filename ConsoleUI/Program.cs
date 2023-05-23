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
            #region TestV1
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //carManager.Add(new Car() { Id = 5, BrandId = 5, ColorId = 5, Description = "Seat Leon 1.4 TSI", DailyPrice = 75, ModelYear = 2020 });
            //Console.WriteLine("Add Methodu Çalıştırıldı");
            //Console.WriteLine("------------------------");
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.Description);
            //}
            //Console.WriteLine("------------------------");
            //Console.WriteLine("Delete Methodu Çalıştırıldı");
            //Console.WriteLine("------------------------");

            //carManager.Delete(5);
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.Description);
            //}
            //Console.WriteLine("------------------------");
            //Console.WriteLine("Update Methodu Çalıştı BMW 320d M3 olarak değiştirildi");
            //Console.WriteLine("------------------------");

            //carManager.Update(new Car() { Id = 2,Description="BMW M3 " });
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.Description);
            //}
            //Console.WriteLine("------------------------");
            //Console.WriteLine("GetById Methodu Çalıştırıldı");
            //Console.WriteLine("------------------------");

            //Console.WriteLine(carManager.GetById(3).Description);
            //Console.WriteLine("------------------------");
            #endregion
            #region Brand
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            ////brandManager.Add(new Brand() { BrandName = "BMW" });
            //Console.WriteLine("---------------------------");
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine("{0}",brand.BrandName);
            //}
            //Console.WriteLine("---------------------------");
            ////brandManager.Delete(new Brand() { BrandId = 2 });
            ////brandManager.Delete(new Brand() { BrandId = 3 });
            //Console.WriteLine("---------------------------");
            //brandManager.Update(new Brand() { BrandId = 5, BrandName = "Audi" });
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine("{0}", brand.BrandName);
            //}
            #endregion
            #region Color
            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(new Color() { ColorName = "Red" });
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0}", color.ColorName);
            //}
            //Console.WriteLine("-------------------------------");
            //colorManager.Delete(new Color() {ColorId=3});
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0}", color.ColorName);
            //}
            //colorManager.Update(new Color() { ColorId = 2, ColorName = "Blue" });
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0}", color.ColorName);
            //}
            #endregion

            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car() { BrandId = 7, ColorId = 2, Description = "M3", DailyPrice = 250, ModelYear = 2020 });
            //carManager.Update(new Car() { Id = 1, Description = "M3 Coupe",BrandId=7,ColorId=2});
            //Console.WriteLine("----");
            //foreach (var car in carManager.GetCarsByColorId(3))
            //{
            //    Console.WriteLine(car.Description);
            //}

            Console.WriteLine("----");
            foreach (var car in carManager.GetCarsByBrandId(7))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}