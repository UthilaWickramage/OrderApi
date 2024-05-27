using EFModels.Models;
using OrderApi.Dto;

namespace OrderApi.Services.OrderService
{
    public interface IOrderService
    {

        Task<List<Order>> SaveOrder(Order order);

        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrder(int id);
        Task<Order> UpdateOrder(OrderUpdateDto orderUpdateDto);
    }
}
