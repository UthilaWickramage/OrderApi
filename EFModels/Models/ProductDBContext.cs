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

        public ProductDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }




      


    }
}
