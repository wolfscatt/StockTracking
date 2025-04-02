using Entities.Concrete;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppUI.Commands;
using WpfAppUI.Services;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductServiceFrontEnd _productService;
        private readonly ICategoryServiceFrontEnd _categoryService;

        private ObservableCollection<Product> _allProducts; // Tüm veriler burada tutulur
        private ObservableCollection<Product> _products;
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterProducts(); // Her değişiklikte filtre uygula
            }
        }
        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                OnPropertyChanged(nameof(IsEditMode));
            }
        }
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ICommand EditCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddNewCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProductsViewModel()
        {
            _productService = new ProductService(); // Autofac ile çözümlemiş oluyorsun
            _categoryService = new CategoryService();
            Products = new ObservableCollection<Product>();

            EditCommand = new RelayCommand(EditProduct);
            SaveCommand = new RelayCommand(async _ => await SaveChanges());
            CancelCommand = new RelayCommand(Cancel);
            AddNewCommand = new RelayCommand(AddNewProduct);
            DeleteCommand = new RelayCommand(async p => await Delete(p as Product));

            LoadProducts();
            LoadCategories();
        }
        private void EditProduct(object obj)
        {
            if (obj is Product selected)
            {
                SelectedProduct = selected;
                IsEditMode = true;
            }
        }
        private void AddNewProduct(object obj)
        {
            SelectedProduct = new Product(); // Yeni boş ürün
            IsEditMode = true;
        }
        private async Task Delete(Product product)
        {
            if (product == null) return;

            bool confirmed = await DialogService.ShowConfirmation(
                $"{product.ProductName} adlı ürünü silmek istediğinizden emin misiniz?");

            if (!confirmed)
                return;

            IsLoading = true;

            var result = await _productService.DeleteProductAsync(product.ProductId);

            if (result)
            {
                GlobalDataService.Products.Remove(product); // globalden sil
                Products.Remove(product); // ekran listesinden de sil

                LoadProducts();

                await DialogService.ShowInfo("Ürün başarıyla silindi.");
            }

            IsLoading = false;
        }
        private void Cancel(object obj)
        {
            SelectedProduct = null;
            IsEditMode = false;
        }

        private async Task SaveChanges()
        {
            if (SelectedProduct == null)
                return;

            IsLoading = true;

            bool isNew = SelectedProduct.ProductId == 0;

            bool result;
            if (isNew)
                result = await _productService.AddProductAsync(SelectedProduct);
            else
                result = await _productService.UpdateProductAsync(SelectedProduct);

            if (result)
            {
                var category = Categories.FirstOrDefault(c => c.CategoryId == SelectedProduct.CategoryId);
                // Global listeyi güncelle
                if (isNew)
                {
                    SelectedProduct.Category = category;
                    GlobalDataService.Products.Add(SelectedProduct);
                }
                else
                {
                    var existing = GlobalDataService.Products.FirstOrDefault(p => p.ProductId == SelectedProduct.ProductId);
                    if (existing != null)
                    {
                        var index = GlobalDataService.Products.IndexOf(existing);
                        SelectedProduct.Category = category; // Güncelleme sırasında da set et
                        GlobalDataService.Products[index] = SelectedProduct;
                    }

                }

                LoadProducts();
                LoadCategories();

                // Kullanıcıya bilgi ver
                await DialogService.ShowInfo(isNew
                    ? "Yeni ürün başarıyla eklendi."
                    : "Ürün bilgileri güncellendi.");

            }

            SelectedProduct = null;
            IsEditMode = false;
            IsLoading = false;

        }
        private void FilterProducts()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Products = _allProducts;
            }
            else
            {
                var filtered = _allProducts
                    .Where(p => !string.IsNullOrEmpty(p.ProductName) &&
                                p.ProductName.ToLower().Contains(SearchText.ToLower()))
                    .ToList();

                Products = new ObservableCollection<Product>(filtered);
            }
        }

        private async void LoadProducts()
        {
            IsLoading = true;

            var productList = GlobalDataService.Products;

            _allProducts = new ObservableCollection<Product>(productList); // tüm liste
            Products = new ObservableCollection<Product>(productList);     // görüntülenen

            IsLoading = false;
        }
        private async void LoadCategories()
        {
            IsLoading = true;

            var categoryList = GlobalDataService.Categories;

            Categories = new ObservableCollection<Category>(categoryList);     // görüntülenen

            IsLoading = false;
        }
    }
}
