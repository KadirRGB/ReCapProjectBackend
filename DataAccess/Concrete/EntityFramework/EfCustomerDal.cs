using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer, CarDbContext>, ICustomerDal
    {
        
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new CustomerDetailDto{
                                Id = u.Id,
                                Name = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                CompanyName = c.CompanyName
                             };
               return result.ToList();

            }
        }
        
    }
}