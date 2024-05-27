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
          var result =  await productService.getAllProducts();
            return Ok(result);
        }
        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<List<Product>>> getProduct(int id)
        {
            var result = await productService.getProduct(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> addProduct(ProductDto productDto)
        {
            await productService.saveProduct(productDto);
            return  Ok(await productService.getAllProducts());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> updateProduct(ProductDto newProduct)
        {
            var result =  await productService.updateProduct(newProduct);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(await productService.getAllProducts());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> deleteProduct(int id)
        {
            await productService.deleteProduct(id);
            return Ok(await productService.getAllProducts());
        }
    }
}
