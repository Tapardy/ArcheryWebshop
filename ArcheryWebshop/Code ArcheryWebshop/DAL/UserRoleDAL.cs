using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL;

public class UserRoleDAL : IUserRoleDAL
{
    public void AddRoleToUser(int userID, int roleID)
    {
        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(
                "INSERT INTO dbi507362.ArcheryWebshop.User_Role (User_ID, Role_ID) " +
                "VALUES ((SELECT ID FROM dbi507362.ArcheryWebshop.Users WHERE ID = @UserID), @RoleID);",
                connection);
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@RoleID", roleID);
            command.ExecuteNonQuery();
        }

    }

    public List<int> GetRoleIDForUsers(int userID)
    {
        List<int> roleIDs = new List<int>();
        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT Role_ID FROM dbi507362.ArcheryWebshop.User_Role WHERE User_ID = @UserID",
                connection);
            command.Parameters.AddWithValue("@userID", userID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                roleIDs.Add((int)reader["Role_ID"]);
            }

            connection.Close();
        }

        return roleIDs;
    }
}