namespace Basket.Domain.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new();

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart()
        {
        }

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (ShoppingCartItem item in Items)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }
    }
}
