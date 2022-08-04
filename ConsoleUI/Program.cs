using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI{
    class Program{
        static void Main(string[]args){
            CarManager carManager2 = new CarManager(new EfCarDal());
            Car car = new Car(){
                Id=1,
                BrandId=1,
                ColorId=1,
                DailyPrice=120,
                Description="Amd",
                ModelYear=1920
            };
                      
 
           carManager2.Add(car);
            CarTest();
            
        }   

        private static void CarTest(){
            CarManager carManager = new CarManager(new EfCarDal());
            var result =carManager.GetCarDetails();
            if(result.Success)
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + car.BrandName);
            }else{
                  Console.WriteLine(result.Message);
            }
         }
        /* 
         private static void BrandTest(){
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result =brandManager.GetAll();
            if(result.Success)
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }else{
                  Console.WriteLine(result.Message);
            }
         }
         */

    }
}