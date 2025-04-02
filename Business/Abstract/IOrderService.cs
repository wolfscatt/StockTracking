using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> GetById(int orderId);
        IDataResult<List<Order>> GetList();
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
    }
}
