using EFModels.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }


        public string ProductDescription { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public int Qty { get; set; }

        public List<Order> Orders { get; set; }
    }
}
