using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<OrderDetail> GetById(int orderDetailId);
        IDataResult<List<OrderDetail>> GetList();
    }
}
