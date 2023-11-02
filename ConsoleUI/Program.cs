// See httpusing Business.Concrete;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarBrandColorAdded();
            //Test2();
            //BrandTest();
            //ColorTest();
            //CarTest();  


        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();

            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Name);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Name);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Add(new Car { Name = "a", BrandId = 414, ColorId = 323, ModelYear = 2022, DailyPrice = 400, Description = "otomatik" });
            Console.WriteLine(result.Message);

            foreach (var c in carManager.GetCarsDetails().Data)
            {
                Console.WriteLine(c.DailyPrice + " >> " + c.BrandName + " >> " + c.ColorName);
            }




        }
    }

    //public static void Test2()
    //{
    //    CarManager carManager = new CarManager(new EfCarDal());

    //    foreach (var item in carManager.GetCarsDetails().Data)
    //    {
    //        Console.WriteLine("Car NAME: "  +  item.CarName + " / Brand Name: " + item.BrandName + " / Color Name: " + item.ColorName + " / Daily Price: " + item.DailyPrice);

    //    }
    //}

    //public static void CarBrandColorAdded()
    //{
    //    //CarManager carManager = new CarManager(new InMemoryCarDal());

    //    //foreach (var item in carManager.GetAll())
    //    //{
    //    //    Console.WriteLine(item.DailyPrice);

    //    //}
    //    Console.WriteLine(" *** Merhaba Katmanlı Mimari Projesine Hoşgeldiniz ***");


    //    Color color1 = new Color() { Id = 1, Name = "Mavi" };
    //    Color color2 = new Color() { Id = 2, Name = "Kırmızı" };

    //    ColorManager colorManager = new ColorManager(new EfColorDal());
    //    colorManager.Add(color1);
    //    colorManager.Add(color2);



    //    Brand brand1 = new Brand() { Id = 1, Name = "A" };
    //    Brand brand2 = new Brand() { Id = 2, Name = "B" };

    //    BrandManager brandManager = new BrandManager(new EfBrandDal());
    //    brandManager.Add(brand1);
    //    brandManager.Add(brand2);




    //    CarManager carManager = new CarManager(new EfCarDal());
    //    Car car1 = new Car() { Id = 1, Name = "Toyota", BrandId = 1, ColorId = 1, ModelYear = 2023, DailyPrice = 1453, Description = "Test " };
    //    Car car2 = new Car() { Id = 2, Name = "Ranault", BrandId = 2, ColorId = 2, ModelYear = 2008, DailyPrice = 15, Description = "26 / 10 / 2022 ikinci kayıt" };
    //    carManager.Add(car1);
    //    carManager.Add(car2);


    //}
 //}
    
}
