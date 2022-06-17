namespace Basket.Application.Models
{
    public sealed class ShoppingCartDto
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemDto> Items { get; set; } = new();
        public decimal TotalPrice { get; set; } = 0;
    }
}
