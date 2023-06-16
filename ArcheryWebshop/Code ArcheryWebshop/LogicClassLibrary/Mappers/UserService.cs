using DAL.DTO;
using DAL.Interface;
using Microsoft.Identity.Client;

namespace WebshopClassLibrary.Mappers
{
    public class UserService
    {
        private readonly IUserDAL _userDAL;

        public UserService(IUserDAL userDal)
        {
            _userDAL = userDal;
        }

        public User GetUserByID(int userID)
        {
            UserDTO userDto = _userDAL.GetUserByID(userID);
            return MapToUser(userDto);
        }

        public User GetUserByName(string username)
        {
            UserDTO userDto = _userDAL.GetUserByName(username);
            return MapToUser(userDto);
        }

        public void AddUser(User user)
        {
            UserDTO userDto = MapToUserDTO(user);
            _userDAL.AddUser(userDto);
        }

        public void UpdateUser(User user)
        {
            UserDTO userDto = MapToUserDTO(user);
            _userDAL.UpdateUser(userDto);
        }

        private User MapToUser(UserDTO userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new User
            {
                ID = userDto.ID,
                Name = userDto.Name,
                Password = userDto.Password
            };
        }

        private UserDTO MapToUserDTO(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                ID = user.ID,
                Name = user.Name,
                Password = user.Password
            };
        }
    }
}