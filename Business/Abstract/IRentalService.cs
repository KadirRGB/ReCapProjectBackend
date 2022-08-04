using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
     IDataResult<Rental> GetById(int rentalId);
     IResult Add(Rental rental);
     IResult Update(Rental rental);
     IResult Delete(Rental rental);
     
     IDataResult<List<RentalDetailDto>>GetRentalDetails();

         
    }
}