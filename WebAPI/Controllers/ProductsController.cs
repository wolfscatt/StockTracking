using Business.Abstract;
using Business.Concrete.Managers;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getAll")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                UnitPrice = productDto.UnitPrice,
                UnitsInStock = productDto.UnitsInStock,
                Description = productDto.Description
            };
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(int productId, ProductDto productDto)
        {
            var getProduct = _productService.GetById(productId).Data;
            if (productId == getProduct.ProductId)
            {
                getProduct.ProductName = productDto.ProductName;
                getProduct.CategoryId = productDto.CategoryId;
                getProduct.UnitPrice = productDto.UnitPrice;
                getProduct.UnitsInStock = productDto.UnitsInStock;
                getProduct.Description = productDto.Description;
            }

            var result = _productService.Update(getProduct);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int productId)
        {
            var getProduct = _productService.GetById(productId).Data;

            var result = _productService.Delete(getProduct);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
