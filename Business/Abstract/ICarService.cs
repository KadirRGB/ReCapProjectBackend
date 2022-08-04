using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
           IDataResult<List<Car>> GetAll();
           IDataResult<List<Car>> GetCarsByBrandId(int Id);
           IDataResult<List<Car>> GetCarsByColorId (int Id);
           IDataResult<List<CarDetailDto>> GetCarDetails();
           IDataResult<Car>GetById(int carId);
         IResult Add(Car car);
         IResult Update(Car car);
         IResult Delete(Car car);

    }
}