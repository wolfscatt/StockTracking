using DataAccess.Abstract.IRepository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        // Order-specific operations
    }
}
