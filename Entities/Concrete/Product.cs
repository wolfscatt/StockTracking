using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Product()
        {
            
        }

        public override string ToString()
        {
            return $"Product Id:{ProductId}" +
                $"\nProduct Name:{ProductName}" +
                $"\nCategory Id:{CategoryId}" +
                $"\nUnit Price:{UnitPrice}" +
                $"\nUnits In Stock:{UnitsInStock}" +
                $"\nDescription:{Description}" +
                $"\nPurchase Date:{PurchaseDate}" +
                $"\nUpdated Date:{UpdatedDate}";
        }
    }
}
