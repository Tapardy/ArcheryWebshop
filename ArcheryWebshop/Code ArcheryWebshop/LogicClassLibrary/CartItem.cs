namespace WebshopClassLibrary;

public class CartItem
{
    public int UserID;
    public int ProductID { get; set; }
    public int CartItemID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; }
}
