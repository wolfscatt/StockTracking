using DataAccess.Abstract.IRepository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
        // OrderDetail-specific operations
    }
}
