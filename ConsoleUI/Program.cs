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
            //Test1();
           Test2();


        }

        private static void Test2()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarsDetails())
            {
                Console.WriteLine(item.CarName + "/" + item.BrandName + "/" + item.ColorName + "/" + item.DailyPrice);
               
            }
        }

        private static void Test1()
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.DailyPrice);

            //}
            Console.WriteLine(" *** Merhaba Katmanlı Mimari Projesine Hoşgeldiniz ***");


            Color color1 = new Color() { Id = 1, Name = "Mavi" };
            Color color2 = new Color() { Id = 2, Name = "Kırmızı" };

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color1);
            colorManager.Add(color2);
            List<Color> colorList = colorManager.GetAll();
            Console.WriteLine("****************  Sisteme Kayıtlı RENKLER Listeleniyor **********************");
            foreach (var color in colorList)
            {
                Console.WriteLine("Color Id : {0} , Color Name : {1} ", color.Id, color.Name);
            }


            Brand brand1 = new Brand() { Id = 1, Name = "Toyota" };
            Brand brand2 = new Brand() { Id = 2, Name = "Ranault" };

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand1);
            brandManager.Add(brand2);

            Console.WriteLine("****************  Sisteme Kayıtlı MARKALAR Listeleniyor **********************");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka ID : {0} , Marka Adı : {1}", brand.Id, brand.Name);
            }


            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { Id = 1, Name = "Toyota", BrandId = 1, ColorId = 1, ModelYear = 2023, DailyPrice = 1453, Description = "Test " };
            Car car2 = new Car() { Id = 2, Name = "Ranault", BrandId = 2, ColorId = 2, ModelYear = 2008, DailyPrice = 15, Description = "26 / 10 / 2022 ikinci kayıt" };
            carManager.Add(car1);
            carManager.Add(car2);

            Console.WriteLine("****************  Sisteme Kayıtlı Bütün Araçlar Listeleniyor **********************");

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Araç ID:" + car.Id + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
            }

            Console.WriteLine("****************  Sisteme Kayıtlı BrandId=9 Olan Araçlar Listeleniyor **********************");
            foreach (Car car in carManager.GetCarsByBrandId(9))
            {
                Console.WriteLine("Araç ID:" + car.Id + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
            }

            Console.WriteLine("****************  Sisteme Kayıtlı ColorID=88 Olan Araçlar Listeleniyor **********************");
            foreach (Car car in carManager.GetCarsByColorId(88))
            {
                Console.WriteLine("Araç ID:" + car.Id + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
            }
        }
    }
}
