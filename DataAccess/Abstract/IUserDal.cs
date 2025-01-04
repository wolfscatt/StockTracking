using DataAccess.Abstract.IRepository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        // User-specific operations
    }
}
