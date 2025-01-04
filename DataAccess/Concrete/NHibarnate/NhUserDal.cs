using DataAccess.Abstract;
using DataAccess.Concrete.NHibarnate.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibarnate
{
    public class NhUserDal : NhEntityRepositoryBase<User>, IUserDal
    {
        public NhUserDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
