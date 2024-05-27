using EFModels.Models;
using OrderApi.Dto;

namespace OrderApi.Services.ProductService
{
    public interface IProductService
    {
        Task<Product> saveProduct(ProductDto productDto);
        Task<List<Product>> getAllProducts();

        Task<Product> getProduct(int id);

        Task<Product> updateProduct(ProductDto productDto);

        Task deleteProduct(int id);
    }
}
