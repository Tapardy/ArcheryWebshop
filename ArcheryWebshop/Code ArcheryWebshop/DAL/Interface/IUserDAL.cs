using DAL.DTO;

namespace DAL.Interface
{
    public interface IUserDAL
    {
        UserDTO GetUserByID(int userID);
        UserDTO GetUserByName(string username);
        void AddUser(UserDTO user);
        void UpdateUser(UserDTO user);
    }
}