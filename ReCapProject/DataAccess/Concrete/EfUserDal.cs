

using Core.DataAccess.EntityFramework;
using Entities;

namespace DataAccess
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {

    }
}
