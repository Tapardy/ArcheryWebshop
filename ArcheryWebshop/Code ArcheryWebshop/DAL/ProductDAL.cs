using DAL.DTO;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL;

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
            SqlCommand command = new SqlCommand("SELECT * FROM dbi507362.ArcheryWebshop.Product WHERE ID = @Id",
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
}