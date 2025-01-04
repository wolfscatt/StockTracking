using DataAccess.Abstract.IRepository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        // Category-specific operations
    }
}
