using Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DataAccess.Concrete.NHibarnate.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table(@"Orders");
            LazyLoad();
            Id(x => x.OrderId).Column("OrderId");
            Map(x => x.OrderDate).Column("OrderDate");
            Map(x => x.CustomerId).Column("CustomerId");
            Map(x => x.TotalAmount).Column("TotalAmount");
            References(x => x.Customer).Column("CustomerId");
        }
    }
}
