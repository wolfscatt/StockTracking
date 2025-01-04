using Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
