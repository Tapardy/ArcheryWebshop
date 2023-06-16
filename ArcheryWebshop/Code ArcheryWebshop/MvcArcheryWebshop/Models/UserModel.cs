namespace MvcArcheryWebshop.Models;

public class UserModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string ErrorMessage { get; set; }
    public List<int> RoleIDs { get; set; }
    
    public UserModel()
    {
        RoleIDs = new List<int>();
    }
}