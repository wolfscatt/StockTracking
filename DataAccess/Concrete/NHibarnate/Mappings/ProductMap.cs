using Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.NHibarnate.Mappings
{
    public class ProductMap: ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");

            LazyLoad();

            Id(x => x.ProductId).Column("ProductId");

            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.UnitsInStock).Column("UnitsInStock");
            Map(x => x.Description).Column("Description");
            Map(x => x.PurchaseDate).Column("PurchaseDate");
            Map(x => x.UpdatedDate).Column("UpdatedDate");

            References(x => x.Category).Column("CategoryId");


        }
    }
}
