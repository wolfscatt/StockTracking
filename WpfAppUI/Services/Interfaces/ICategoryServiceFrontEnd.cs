using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppUI.Services.Interfaces
{
    public interface ICategoryServiceFrontEnd
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
