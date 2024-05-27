using EFModels.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;

namespace OrderApi.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public readonly ProductDBContext _productDBContext;
        public OrderService(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }

        public async Task<List<Order>> GetOrdersAsync() 
        {
            return await _productDBContext.Orders.Include(o=>o.Items).ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
          
               var order = await _productDBContext.Orders.Include(o=>o.Items).FirstOrDefaultAsync(o=>o.Id==id);
            if (order == null)
            {
                throw new NullReferenceException();
            }
            return order;
        }

        public async Task<List<Order>> SaveOrder(Order order)
        {
            _productDBContext.Orders.Add(order);
            await _productDBContext.SaveChangesAsync();
            return await GetOrdersAsync();
        }

        public async Task<Order> UpdateOrder(OrderUpdateDto orderUpdateDto)
        {
            var order = await GetOrder(orderUpdateDto.OrderId);

            if (order == null)
            {
                throw new NullReferenceException();
            }
            
            if(orderUpdateDto.OrderStatus == 1)
            {
                order.OrderStatus = OrderStatus.VERIFED;
            }else if(orderUpdateDto.OrderStatus == 2)
            {
                order.OrderStatus = OrderStatus.SHIPPED;
            }else if(orderUpdateDto.OrderStatus == 3)
            {
                order.OrderStatus = OrderStatus.DELIVERED;
            }
            else
            {
                throw new NotSupportedException();
            }
            _productDBContext.Update(order);
            await _productDBContext.SaveChangesAsync();
            return await GetOrder(orderUpdateDto.OrderId);

        }
    }
}
