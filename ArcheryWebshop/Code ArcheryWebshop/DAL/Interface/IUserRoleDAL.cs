namespace DAL.Interface;

public interface IUserRoleDAL
{
    void AddRoleToUser(int userID, int roleID);
    List<int> GetRoleIDForUsers(int userID);
}