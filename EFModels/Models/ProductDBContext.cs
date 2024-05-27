using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models
{
    public class ProductDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ProductDBContext(DbContextOptions<ProductDBContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public ProductDBContext()
        {
            
        }






    }
}
