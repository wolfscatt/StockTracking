using Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DataAccess.Concrete.NHibarnate.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table(@"Customers");
            LazyLoad();
            Id(x => x.CustomerId).Column("CustomerId");
            Map(x => x.FullName).Column("FullName");
            Map(x => x.Address).Column("Address");
            Map(x => x.Phone).Column("Phone");
            Map(x => x.Email).Column("Email");

            References(x => x.Orders).Column("CustomerId");
        }
    }
}
