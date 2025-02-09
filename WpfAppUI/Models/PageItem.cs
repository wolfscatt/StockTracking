using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppUI.Models
{
    public class PageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; } // MaterialDesignIcon adı
        public string ViewName { get; set; } // Sayfaya yönlendirme için kullanılacak
    }
}
