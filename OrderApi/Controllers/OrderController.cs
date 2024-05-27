using EFModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Dto;
using OrderApi.Services.OrderService;
using OrderApi.Services.ProductService;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> saveOrder(OrderCreateDto orderDto)
        {
          
            var newOrder = new Order();
            newOrder.Total = orderDto.Total;
            newOrder.customerId = orderDto.CustomerId;
            newOrder.OrderStatus = OrderStatus.PENDING;
            
           var orderItems = orderDto.Items.Select(x => new OrderItem { 
                    ProductId = x.ProductId,
                    OrderId = newOrder.Id,
                    Qty = x.Qty
                }).ToList();

            newOrder.Items =orderItems;
            return Ok(await _orderService.SaveOrder(newOrder));
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> getOrder(int id)
        {
            Order order;
            try
            {
               order =  await _orderService.GetOrder(id);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            return order;

        }

        [HttpGet]
        public async Task<ActionResult<Order>> getAllOrders()
        {
            return Ok(await _orderService.GetOrdersAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Order>> ModifyOrder(OrderUpdateDto orderUpdateDto)
        {
            var order = await _orderService.UpdateOrder(orderUpdateDto);
            return Ok(order);
        }

    }
}
