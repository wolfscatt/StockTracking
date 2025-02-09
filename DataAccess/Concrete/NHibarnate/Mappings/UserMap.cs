using Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DataAccess.Concrete.NHibarnate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table(@"Users");
            LazyLoad();
            Id(x => x.UserId).Column("UserId");
            Map(x => x.Username).Column("UserName");
            Map(x => x.Password).Column("Password");
            Map(x => x.FullName).Column("FullName");
            Map(x => x.Role).Column("Role");
            Map(x => x.Email).Column("Email");
            Map(x => x.CreatedDate).Column("CreatedDate");
        }
    }
}
