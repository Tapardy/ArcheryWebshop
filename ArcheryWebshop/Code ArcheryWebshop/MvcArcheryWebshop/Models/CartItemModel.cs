using WebshopClassLibrary;

namespace MvcArcheryWebshop.Models
{
    public class CartItemModel
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }

        public CartItemModel(Product cartItem)
        {
            if (cartItem != null)
            {
                ProductID = cartItem.ID;
                Price = cartItem.Price;
                ProductName = cartItem.Name;
            }
        }


        public CartItemModel()
        {
        }

        public CartItemModel(CartItem cartItem)
        {
            Quantity = cartItem.Quantity;
            ProductID = cartItem.ProductID;
            ProductName = cartItem.ProductName;
            Price = cartItem.Price;
        }
    }
}