using Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DataAccess.Concrete.NHibarnate.Mappings
{
    public class OrderDetailMap :ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Table(@"OrderDetails");
            LazyLoad();
            Id(x => x.OrderDetailId).Column("OrderDetailId");

            Map(x => x.OrderId).Column("OrderId");
            Map(x => x.ProductId).Column("ProductId");
            Map(x => x.Quantity).Column("Quantity");
            Map(x => x.UnitPrice).Column("UnitPrice");

            References(x => x.Order).Column("OrderId");
            References(x => x.Product).Column("ProductId");
        }
    }
}
