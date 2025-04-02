using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppUI.Services
{
    public static class GlobalDataService
    {
        public static ObservableCollection<Product> Products { get; set; } = new();
        public static ObservableCollection<Category> Categories { get; set; } = new();
        public static int TotalStockAmount { get; set; } = 0;
        public static int CriticalStockCount { get; set; } = 0;

        public static bool IsDataLoaded { get; set; } = false;
    }
}
