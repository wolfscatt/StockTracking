using Autofac;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.DependencyResolvers;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.Services
{
    public class CategoryService : ICategoryServiceFrontEnd
    {
        private readonly ICategoryService _categoryService;
        public CategoryService()
        {
            _categoryService = IocContainer.Container.Resolve<ICategoryService>();
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await Task.Run(() =>
            {
                var result = _categoryService.GetList();
                if (result.Success)
                {
                    return result.Data;
                }
                return new List<Category>();
            });
        }
    }
}
