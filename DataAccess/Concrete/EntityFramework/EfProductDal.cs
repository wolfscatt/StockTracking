using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, StockContext>, IProductDal
    {
        
    }
}
