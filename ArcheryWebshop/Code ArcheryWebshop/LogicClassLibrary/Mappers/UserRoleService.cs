using DAL;
using DAL.Interface;

namespace WebshopClassLibrary.Mappers;

public class UserRoleService
{
    private readonly IUserRoleDAL _userRoleDal;

    public UserRoleService(IUserRoleDAL userRoleDal)
    {
        _userRoleDal = userRoleDal;
    }
    
    public void AddRoleToUser(int userID, int roleID)
    {
        _userRoleDal.AddRoleToUser(userID, roleID);
    }
    
    public List<int> GetRoleIDForUsers(int userID)
    {
        return _userRoleDal.GetRoleIDForUsers(userID);
    }
}