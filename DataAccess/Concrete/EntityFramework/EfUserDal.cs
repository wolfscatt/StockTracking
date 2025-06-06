﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, StockContext>, IUserDal
    {
    }
}
