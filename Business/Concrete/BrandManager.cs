using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p=>p.Id==brandId));
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(),brand);

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }
          public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
             return new SuccessResult(Messages.Updated);

        }
        public IResult Delete(Brand brand)
        {
           _brandDal.Delete(brand);
             return new SuccessResult(Messages.Deleted);       }

        public IDataResult<List<Brand>> GetAll()
        {
      return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);

        }

        

      
    }
}