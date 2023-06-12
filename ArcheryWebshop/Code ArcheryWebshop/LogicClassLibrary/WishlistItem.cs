namespace WebshopClassLibrary;

public class WishlistItem
{
    public int UserID;
    public int ProductID { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
}