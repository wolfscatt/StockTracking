﻿using Entities.Abstract;
using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.IRepository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
