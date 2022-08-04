using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
          IDataResult<CarImage>GetById(int carImageId);
          IDataResult<List<CarImage>> GetAllByCarId(int carId);

          IDataResult<List<CarImage>> GetAll();
          IResult Add(IFormFile file, CarImage carImage);
          IResult Update(IFormFile file, CarImage carImage);
          IResult Delete(CarImage carImage);

    }
}