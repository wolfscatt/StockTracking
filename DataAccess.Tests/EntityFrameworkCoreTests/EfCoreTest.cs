using DataAccess.Concrete.EntityFramework;

namespace DataAccess.Tests;

public class EfCoreTest
{
    [Fact]
    public void Get_all_returns_all_products()
    {
        EfProductDal productDal = new EfProductDal();

        var result = productDal.GetAll();

        Assert.Equal(2, result.Count);
    }
}
