using DAL.DTO;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        public UserDTO GetUserByID(int userID)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbi507362.ArcheryWebshop.Users WHERE ID = @ID",
                    connection);
                command.Parameters.AddWithValue("@ID", userID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserDTO user = new UserDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Password = (string)reader["Password"]
                    };

                    return user;
                }

                return null;
            }
        }

        public UserDTO GetUserByName(string username)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbi507362.ArcheryWebshop.Users WHERE Name = @Name",
                    connection);
                command.Parameters.AddWithValue("@Name", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserDTO user = new UserDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Password = (string)reader["Password"]
                    };
                    return user;
                }

                return null;
            }
        }

        public void AddUser(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO dbi507362.ArcheryWebshop.Users (Name, Password) VALUES (@Name, @Password)",
                    connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE dbi507362.ArcheryWebshop.Users SET Name = @Name, Password = @Password WHERE ID = @ID",
                    connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@ID", user.ID);

                command.ExecuteNonQuery();
            }
        }
    }
}