using EFModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;
using OrderApi.Services.ProductService;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> getAllProducts()
        {
          var result =   productService.getAllProducts();
            return Ok(result);
        }
        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<List<Product>>> getProduct(int id)
        {
            var result = productService.getProduct(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> addProduct(ProductDto productDto)
        {
            productService.saveProduct(productDto);
            return Ok(productService.getAllProducts());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> updateProduct(ProductDto newProduct)
        {
            var result =  productService.updateProduct(newProduct);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(productService.getAllProducts());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> deleteProduct(int id)
        {
            productService.deleteProduct(id);
            return Ok(productService.getAllProducts());
        }
    }
}
