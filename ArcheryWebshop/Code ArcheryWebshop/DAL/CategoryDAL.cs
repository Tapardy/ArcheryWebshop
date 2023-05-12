using System.Collections.Generic;
using DAL.DTO;
using System.Data.SqlClient;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private ICategoryDAL _categoryDalImplementation;
        public List<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();

            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CategoryDTO category = new CategoryDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        ImageUrl = (string)reader["Image"]
                        // Map other category properties
                    };

                    categories.Add(category);
                }

                reader.Close();
                connection.Close();
            }

            return categories;
        }

        public CategoryDTO GetCategoryById(int categoryId)
        {
            CategoryDTO category = null;

            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE ID = @CategoryId", connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    category = new CategoryDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        // Map other category properties
                    };
                }

                reader.Close();
                connection.Close();
            }

            return category;
        }

        public void AddCategory(CategoryDTO category)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Categories (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", category.Name);
                // Set other category properties as parameters if needed
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditCategory(CategoryDTO category)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Categories SET Name = @Name WHERE ID = @CategoryId", connection);
                command.Parameters.AddWithValue("@Name", category.Name);
                command.Parameters.AddWithValue("@CategoryId", category.ID);
                // Set other category properties as parameters if needed
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE ID = @CategoryId", connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
