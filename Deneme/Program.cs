using Business.Concrete.Managers;
using DataAccess.Concrete.EntityFramework;

/* Entity Framework Core
EfProductDal productDal = new EfProductDal();
var result = productDal.GetAll(filter => filter.ProductName.Contains("1"));
Console.WriteLine("-----------------------Products-----------------------");
foreach (var product in result)
{
    Console.WriteLine($"Product -> {product.ProductName}");
    Console.WriteLine(product);
    Console.WriteLine("-------------------------");
}
*/
/* NHibernate
NhProductDal productDal = new NhProductDal(new SqlServerHelper());
var result = productDal.GetAll();
Console.WriteLine("-----------------------Products-----------------------");
foreach (var product in result)
{
    Console.WriteLine($"Product -> {product.ProductName}");
    Console.WriteLine(product);
    Console.WriteLine("-------------------------");
}
*/

/* Fluent Validation Aspect için Ninject içerisinde tanımladığım proxylerin sarmaladığı sınıfları burada çözüyorum.
var kernel = new StandardKernel(new BusinessModule());
var productManager = kernel.Get<IProductService>();

Product product = new Product()
{
    ProductName = "",
    CategoryId = 1,
    UnitPrice = 10,
    UnitsInStock = 1,
};

var addedProduct = productManager.Add(product);
Console.WriteLine(addedProduct);
*/

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetList().Data)
    {
        Console.WriteLine(category.CategoryName);
    }
}


Console.ReadKey();
