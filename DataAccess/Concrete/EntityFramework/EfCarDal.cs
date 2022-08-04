using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(){
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                              on c.BrandId equals b.Id
                             join d in context.Colors
                             on c.ColorId equals d.Id
                             select new CarDetailDto{
                                CarName = c.Description,
                                BrandName = b.Name,
                                ColorName = d.Name,
                                DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }                   
        }
       
    }
}
