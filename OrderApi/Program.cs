using EFModels.Models;
using Microsoft.EntityFrameworkCore;
using OrderApi.Services.CustomerService;
using OrderApi.Services.ProductService;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ProductDBContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));


        });
        builder.Services.AddScoped<ICustomerRepository,CustomerService>();
        builder.Services.AddScoped<IProductService, ProductService>();

            //});
            ////    var contextOptions = new DbContextOptionsBuilder<ProductDBContext>()
            ////.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
            ////.Options;

            //using var context = new ProductDBContext(contextOptions);
            //Product product = new Product();
            //product.ProductName = "Banana";
            //product.ProductDescription = "Worlds Greatest food";
            //product.Price = 250;
            //product.Qty = 10;
            //context.Add(product);
            //context.SaveChanges();

            //using (var context = new ProductDBContext())
            //{

            //}

            var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}