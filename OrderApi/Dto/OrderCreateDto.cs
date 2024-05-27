namespace OrderApi.Dto
{
    public record struct OrderCreateDto(int Id, int Total, int CustomerId, List<OrderItemCreateDto>Items);
   
}
