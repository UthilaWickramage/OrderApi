using EFModels.Models;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;

namespace OrderApi.Services.CartService
{
    public class CartService : ICartService
    {
        ProductDBContext _dbContext;
        public CartService(ProductDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<CartItem>> addCartItem(CartItemCreateDto cartItemDto)
        {
            CartItem cartItem = new CartItem();
           
            var customer = await _dbContext.Customers.FindAsync(cartItemDto.customerId);
            if (customer == null)
            {
                throw new NullReferenceException();
            }
            cartItem.CustomerId = cartItemDto.customerId;
            cartItem.Customer = customer;
         
            var product = await _dbContext.Products.FindAsync(cartItemDto.productId);
            if (product == null)
            {
                throw new NullReferenceException();
            }
            cartItem.ProductId = cartItem.ProductId;
            cartItem.Product = product;
            cartItem.Qty = cartItemDto.Qty;
           

            _dbContext.CartItems.Add(cartItem);
            await _dbContext.SaveChangesAsync();
            return await getAllCartItems(cartItem.CustomerId);
        }

        public async Task Delete(int cartId)
        {
            var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.Id == cartId);
            if (cartItem == null)
            {
                throw new NullReferenceException();
            }

            _dbContext.CartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();


        }

        public async Task<List<CartItem>> getAllCartItems(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);
           if (customer == null)
            {
                throw new NullReferenceException();
            }
           var cartItems =  await _dbContext.CartItems.Include(c => c.Customer).Include(c => c.Product).Where(c => c.CustomerId == customerId).ToListAsync();
            return cartItems;
        }

        public async Task<List<CartItem>> updateCartItemQty(CartItemUpdateDto cartItemDto)
        {
            var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.Id == cartItemDto.cartItem_id);
            if (cartItem == null)
            {
                throw new NullReferenceException();
            }
            cartItem.Qty = cartItemDto.Qty;
            _dbContext.CartItems.Update(cartItem);
            await _dbContext.SaveChangesAsync();
            return await getAllCartItems(cartItem.CustomerId);
        }
    }
}
