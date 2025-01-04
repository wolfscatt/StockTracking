using DataAccess.Abstract;
using DataAccess.Concrete.NHibarnate.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibarnate
{
    public class NhOrderDal : NhEntityRepositoryBase<Order>, IOrderDal
    {
        public NhOrderDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
