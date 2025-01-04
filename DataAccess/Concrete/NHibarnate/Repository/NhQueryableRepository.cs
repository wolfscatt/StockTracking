using DataAccess.Abstract.IRepository;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.NHibarnate.Repository
{
    internal class NhQueryableRepository<T> : IQueryableRepository<T>
        where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table => Entities;

        public virtual IQueryable<T> Entities
        {
            get
            {
                return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>());

            }
        }
    }
}



