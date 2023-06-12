using DAL.DTO;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbi507362.ArcheryWebshop.Category",
                    connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CategoryDTO category = new CategoryDTO(
                        (int)reader["ID"],
                        reader["Name"].ToString()
                    );
                    categories.Add(category);
                }

                connection.Close();
            }

            return categories;
        }

        public List<CategoryDTO> GetCategoriesByIds(List<int> categoryIds)
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM dbi507362.ArcheryWebshop.Category WHERE ID IN ({0})";
                string parameterNames = string.Join(",", categoryIds.Select((id, index) => $"@ID{index}"));
                string commandText = string.Format(query, parameterNames);
                SqlCommand command = new SqlCommand(commandText, connection);
                for (int i = 0; i < categoryIds.Count; i++)
                {
                    command.Parameters.AddWithValue($"@ID{i}", categoryIds[i]);
                }

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CategoryDTO category = new CategoryDTO(
                        (int)reader["ID"],
                        reader["Name"].ToString()
                    );
                    categories.Add(category);
                }

                connection.Close();
            }

            return categories;
        }
    }
}