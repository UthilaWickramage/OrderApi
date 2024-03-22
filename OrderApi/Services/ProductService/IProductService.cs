using EFModels.Models;
using OrderApi.Dto;

namespace OrderApi.Services.ProductService
{
    public interface IProductService
    {
        Product saveProduct(ProductDto productDto);
        List<Product> getAllProducts();

        Product getProduct(int id);

        Product updateProduct(ProductDto productDto);

        void deleteProduct(int id);
    }
}
