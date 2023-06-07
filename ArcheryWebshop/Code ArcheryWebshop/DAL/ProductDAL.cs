using DAL.DTO;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ProductDAL : IProductDAL
    {
        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbi507362.ArcheryWebshop.Product", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductDTO product = new ProductDTO(
                        (int)reader["ID"],
                        GetCategoryNameById((int)reader["Category_ID"]), // Retrieve Category Name
                        reader["Name"].ToString(),
                        reader["Image"].ToString(),
                        (decimal)reader["Price"],
                        reader["Description"].ToString()
                    );
                    products.Add(product);
                }

                connection.Close();
            }

            return products;
        }

        public ProductDTO GetProductByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbi507362.ArcheryWebshop.Product WHERE ID = @Id",
                    connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ProductDTO product = new ProductDTO(
                        (int)reader["ID"],
                        GetCategoryNameById((int)reader["Category_ID"]), // Retrieve Category Name
                        reader["Name"].ToString(),
                        reader["Image"].ToString(),
                        (decimal)reader["Price"],
                        reader["Description"].ToString()
                    );
                    return product;
                }

                connection.Close();
            }

            return null;
        }

        public void AddProduct(ProductDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();

                // Retrieve the Category ID based on the provided Category Name
                SqlCommand categoryIdCommand = new SqlCommand(
                    "SELECT ID FROM dbi507362.ArcheryWebshop.Category WHERE Name = @CategoryName;",
                    connection);
                categoryIdCommand.Parameters.AddWithValue("@CategoryName", dto.CategoryName);
                int categoryId = (int)categoryIdCommand.ExecuteScalar();

                // Insert the product using the retrieved Category ID
                SqlCommand insertCommand = new SqlCommand(
                    "INSERT INTO dbi507362.ArcheryWebshop.Product (ID, Category_ID, Name, Image, Price, Description) " +
                    "VALUES (@ID, @Category_ID, @Name, @Image, @Price, @Description);",
                    connection);
                insertCommand.Parameters.AddWithValue("@ID", dto.ID);
                insertCommand.Parameters.AddWithValue("@Category_ID", categoryId);
                insertCommand.Parameters.AddWithValue("@Name", dto.Name);
                insertCommand.Parameters.AddWithValue("@Image", dto.ImageUrl);
                insertCommand.Parameters.AddWithValue("@Price", dto.Price);
                insertCommand.Parameters.AddWithValue("@Description", dto.Description);
                insertCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void EditProduct(ProductDTO product)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "UPDATE dbi507362.ArcheryWebshop.Product SET Category_ID = (SELECT ID FROM dbi507362.ArcheryWebshop.Category WHERE Name = @CategoryName), " +
                    "Name = @Name, Image = @Image, Price = @Price, Description = @Description WHERE ID = @ID",
                    connection);
                command.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Image", product.ImageUrl);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@ID", product.ID);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();

            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "SELECT ID, Name FROM dbi507362.ArcheryWebshop.Category",
                    connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CategoryDTO category = new CategoryDTO
                    {
                        ID = (int)reader["ID"],
                        Name = reader["Name"].ToString()
                    };

                    categories.Add(category);
                }

                connection.Close();
            }

            return categories;
        }
        
        public void DeleteProduct(int ID)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "DELETE FROM dbi507362.ArcheryWebshop.Product WHERE ID = @ID",
                    connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Helper method to retrieve the Category Name based on the Category ID
        private string GetCategoryNameById(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "SELECT Name FROM dbi507362.ArcheryWebshop.Category WHERE ID = @CategoryID",
                    connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                string categoryName = command.ExecuteScalar()?.ToString();
                connection.Close();

                return categoryName;
            }
        }
    }
}
