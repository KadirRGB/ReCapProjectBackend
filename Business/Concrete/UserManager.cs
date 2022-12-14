using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.Id==userId));
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);         }
        public IResult Update(User user)
        {
             _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(User user)
        {
             _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        

        
    }
}