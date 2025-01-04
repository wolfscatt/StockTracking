using DataAccess.Abstract.IRepository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        // Customer-specific operations
    }
}
