using EFModels.Models;
using FakeItEasy;
using FluentAssertions;
using OrderApi.Dto;
using OrderApi.Services.ProductService;

namespace OrderAPI.Tests.ProductServiceTests
{
    public class ProductServiceTests
    {
        IProductService _productService;
        public ProductServiceTests()
        {
           _productService =  A.Fake<IProductService>();
        }
        [Fact]
        public void ProductService_getAllProducts_isSuccess()
        {
            //arrange

            //act

            var result = _productService.getAllProducts();

            //assert
            result.Should().BeOfType<Task<List<Product>>>();
        }

        [Fact]
        public void ProductService_getProduct_isSuccess()
        {
            //arrange
            int id = 1;
            //act

            var result = _productService.getProduct(id);

            //assert
            result.Should().BeOfType<Task<Product>>();
        }

        [Fact]
        public void ProductService_saveProduct_isSuccess()
        {
            //arrange
          var dto = A.Fake<ProductDto>();

            //act
           var result =  _productService.saveProduct(dto);

            //assert

            result.Should().BeOfType<Task<Product>>();
            
        }

        [Fact]
        public void ProductService_updateProduct_isSuccess()
        {
            //arrange
            var dto = A.Fake<ProductDto>();

            //act
            var result = _productService.updateProduct(dto);

            //assert

            result.Should().BeOfType<Task<Product>>();

        }

        [Fact]
        public void ProductService_deleteProduct_isSuccess()
        {
            //arrange
            int id = 1;

            //act
            var result = _productService.deleteProduct(id);

            //assert

            result.Should().BeOfType<Task>();

        }
    }
}