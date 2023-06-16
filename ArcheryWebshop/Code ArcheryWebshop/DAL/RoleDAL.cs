using DAL.DTO;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL;

public class RoleDAL : IRoleDAL
{
    public RoleDTO GetRoleByID(int roleID)
    {
        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM dbi507362.ArcheryWebshop.Role WHERE ID = @ID",
                connection);
            command.Parameters.AddWithValue("@ID", roleID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                RoleDTO role = new RoleDTO()
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                };

                return role;
            }

            return null;
        }
    }
    
    public List<RoleDTO> GetAllRoles()
    {
        List<RoleDTO> roles = new List<RoleDTO>();

        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM dbi507362.ArcheryWebshop.Role", connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                RoleDTO role = new RoleDTO()
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                };

                roles.Add(role);
            }
        }

        return roles;
    }


    public RoleDTO GetRoleByName(string name)
    {
        throw new NotImplementedException();
    }
}