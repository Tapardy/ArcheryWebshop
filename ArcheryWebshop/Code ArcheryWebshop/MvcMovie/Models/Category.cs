
namespace MvcArcheryWebshop.Models;

public class Category
{
    public static List<string> bowType {get; set;}
    public int handle { get; set; }
    public string? limb { get; set; }
    public string? quiver { get; set; }
    public string? arrow { get; set; }
    public decimal Price { get; set; }
}
