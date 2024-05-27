using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFModels.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int customerId { get; set; }
        public OrderStatus OrderStatus {  get; set; }       
        public List<OrderItem> Items { get; set; }
    }
}
