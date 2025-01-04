using DataAccess.Abstract;
using DataAccess.Concrete.NHibarnate.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibarnate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
