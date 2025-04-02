using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete.Managers
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IDataResult<OrderDetail> GetById(int orderDetailId)
        {
            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(od => od.OrderDetailId == orderDetailId));
        }

        public IDataResult<List<OrderDetail>> GetList()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll().ToList());
        }
    }
}
