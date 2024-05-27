using EFModels.Models;
using OrderApi.Dto;

namespace OrderApi.Services.CartService
{
    public interface ICartService
    {
        Task<List<CartItem>> getAllCartItems(int customerId);
        Task Delete(int cartId);

        Task<List<CartItem>> updateCartItemQty(CartItemUpdateDto cartItemDto);

        Task<List<CartItem>> addCartItem(CartItemCreateDto cartItem);
    }
}
