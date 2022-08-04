using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }   
        
        public IDataResult<Rental> GetById(int rentalId)    
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=>p.Id==rentalId));
        }
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);       
        }     
           public IResult Update(Rental rental)
        { 
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);  
            }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);     
            }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
              return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}