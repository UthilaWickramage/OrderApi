namespace OrderApi.Dto
{
    public record struct CartItemCreateDto(int productId, int customerId, int Qty);
    
}
