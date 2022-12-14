using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
         public IDataResult<Car>GetById(int carId){
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==carId));
         }

         [ValidationAspect(typeof(CarValidator))]
         public IResult Add(Car car){
              ValidationTool.Validate(new CarValidator(),car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
         }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

          public IDataResult<List<Car>> GetAll()
        {
              if(DateTime.Now.Hour==24){
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

          public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
              return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
       return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId == Id));
        }

         public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId == Id));
        }
        



        
    }
}