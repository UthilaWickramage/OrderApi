using EFModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Authentication;
using OrderApi.Dto;
using OrderApi.Services.CartService;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
           _cartService = cartService;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<CartItem>>> getAllCartItems(int Id)
        {
            return Ok(await _cartService.getAllCartItems(Id));
        }

        [HttpPost]
        public async Task<ActionResult<List<CartItem>>> AddCartItem(CartItemCreateDto cartItemCreateDto)
        {
            try
            {
                return Ok(await _cartService.addCartItem(cartItemCreateDto));

            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<CartItem>>> UpdateCartQty(CartItemUpdateDto cartItemUpdateDto)
        {
            var cartItems = await _cartService.updateCartItemQty(cartItemUpdateDto);
            return Ok(cartItems);
        }
 

        [HttpDelete]
        public async Task<ActionResult> deleteCartItem(int cartItem_id)
        {
            try
            {
                await _cartService.Delete(cartItem_id);
            }catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

    }
}
