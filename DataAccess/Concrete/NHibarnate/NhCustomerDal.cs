using DataAccess.Abstract;
using DataAccess.Concrete.NHibarnate.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibarnate
{
    public class NhCustomerDal : NhEntityRepositoryBase<Customer>, ICustomerDal
    {
        public NhCustomerDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
