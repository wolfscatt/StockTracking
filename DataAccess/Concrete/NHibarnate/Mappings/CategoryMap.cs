﻿using Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DataAccess.Concrete.NHibarnate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryId");
            Map(x => x.CategoryName).Column("CategoryName");

            References(x => x.Products).Column("CategoryId");
        }
    }
}
