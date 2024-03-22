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
        public void deleteProduct(int id)
        {
            var dbProduct =  _dbContext.Products.Find(id);
            if (dbProduct == null)
            {
                return;
            }
            _dbContext.Products.Remove(dbProduct);

            _dbContext.SaveChanges();
        }

        public List<Product> getAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product getProduct(int id)
        {
            var product =  _dbContext.Products.Find(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public Product saveProduct(ProductDto productDto)
        {
            Product product = new Product();

            product.ProductName = productDto.ProductName;
            product.ProductDescription = productDto.ProductDescription;
            product.Price = productDto.Price;
            product.Qty = productDto.Qty;
            product.Discount = productDto.Discount;

            _dbContext.Products.Add(product);
             _dbContext.SaveChanges();
            return product;
        }

        public Product updateProduct(ProductDto productDto)
        {
            var dbProduct = _dbContext.Products.Find(productDto.Id);
            if (dbProduct == null)
            {
                return null;
            }
            dbProduct.ProductName = productDto.ProductName;
            dbProduct.ProductDescription = productDto.ProductDescription;
            dbProduct.Price = productDto.Price;
            dbProduct.Qty = productDto.Qty;
            dbProduct.Discount = productDto.Discount;
            _dbContext.SaveChanges();
            return dbProduct;
        }
    }
}
