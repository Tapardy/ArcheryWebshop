using DAL.DTO;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ProductDAL : IProductDAL
    {
        public List<ProductDTO> GetAllProducts()
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
                SqlCommand command = new SqlCommand(
                    "INSERT INTO dbi507362.ArcheryWebshop.Product (ID, Name, Image, Price, Description) " +
                    "VALUES (@ID, @Name, @Image, @Price, @Description);",
                    connection);
                command.Parameters.AddWithValue("@ID", dto.ID);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Image", dto.ImageUrl);
                command.Parameters.AddWithValue("@Price", dto.Price);
                command.Parameters.AddWithValue("@Description", dto.Description);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditProduct(ProductDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "UPDATE dbi507362.ArcheryWebshop.Product SET Name = @Name, Price = @Price, Image = @Image, Description = @Description WHERE ID = @Id",
                    connection);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@Image", dto.ImageUrl);
                command.Parameters.AddWithValue("@Price", dto.Price);
                command.Parameters.AddWithValue("@ID", dto.ID);
                command.Parameters.AddWithValue("@Description", dto.Description);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteProduct(int Id)
        {
            using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "DELETE FROM dbi507362.ArcheryWebshop.Product WHERE ID = @Id",
                    connection);
                command.Parameters.AddWithValue("@ID", Id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}