using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class StockContextFactory : IDesignTimeDbContextFactory<StockContext>
    {
        public StockContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockContext>();
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3D47NNN\\SQLEXPRESS;Initial Catalog=StockTrackingDb;Integrated Security=True");

            return new StockContext(optionsBuilder.Options);
        }
    }
}
