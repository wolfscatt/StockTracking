using DataAccess.Abstract;
using DataAccess.Concrete.NHibarnate.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibarnate
{
    public class NhOrderDetailDal : NhEntityRepositoryBase<OrderDetail>, IOrderDetailDal
    {
        public NhOrderDetailDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
