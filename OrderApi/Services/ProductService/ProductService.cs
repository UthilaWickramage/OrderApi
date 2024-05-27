using EFModels.Models;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;

namespace OrderApi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ProductDBContext _dbContext;

        public ProductService(ProductDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task deleteProduct(int id)
        {
            var dbProduct =  _dbContext.Products.Find(id);
            if (dbProduct != null)
            {
                _dbContext.Products.Remove(dbProduct);

            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> getProduct(int id)
        {
            var product =  await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<Product> saveProduct(ProductDto productDto)
        {
            Product product = new Product();

            product.ProductName = productDto.ProductName;
            product.ProductDescription = productDto.ProductDescription;
            product.Price = productDto.Price;
            product.Qty = productDto.Qty;
            product.Discount = productDto.Discount;

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> updateProduct(ProductDto productDto)
        {
            var dbProduct = await _dbContext.Products.FindAsync(productDto.Id);
            if (dbProduct == null)
            {
                return null;
            }
            dbProduct.ProductName = productDto.ProductName;
            dbProduct.ProductDescription = productDto.ProductDescription;
            dbProduct.Price = productDto.Price;
            dbProduct.Qty = productDto.Qty;
            dbProduct.Discount = productDto.Discount;
            await _dbContext.SaveChangesAsync();
            return dbProduct;
        }
    }
}
