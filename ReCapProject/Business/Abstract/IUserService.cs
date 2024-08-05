using Core.Interceptors.Utilities.Results;
using Entities;

namespace Business
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByUserId(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
       
    }
}
