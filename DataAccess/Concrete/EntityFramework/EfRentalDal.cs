using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDbContext>, IRentalDal
    {
       public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join re in context.Rentals
                             on ca.Id equals re.CarId
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             from u in context.Users
                             join cu in context.Customers
                             on u.Id equals cu.UserId
                             select new RentalDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 ModelName = ca.Description,
                                 RentalId = re.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 CustomerName=u.FirstName,
                                 CustomerLastname=u.LastName

                             };
                return result.ToList();
            }
    }
    }
}