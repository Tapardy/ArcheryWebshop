using System.Data;
using DAL.Interface;
using Microsoft.Data.SqlClient;

namespace DAL;

public class CategoryProductDAL : ICategoryProductDAL
{
    public void AddCategoryToProduct(int categoryId, int productId)
    {
        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO dbi507362.ArcheryWebshop.Category_Product (Category_ID, Product_ID) " +
                "VALUES (@CategoryId, @ProductId);",
                connection);
            command.Parameters.AddWithValue("@CategoryId", categoryId);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<int> GetCategoryIdsForProduct(int productId)
    {
        List<int> categoryIds = new List<int>();
        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "SELECT Category_ID FROM dbi507362.ArcheryWebshop.Category_Product WHERE Product_ID = @ProductId",
                connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categoryIds.Add((int)reader["Category_ID"]);
            }

            connection.Close();
        }

        return categoryIds;
    }

    public void RemoveCategoriesFromProduct(int productId)
    {
        using (SqlConnection connection = new SqlConnection(Secrets.ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "DELETE FROM dbi507362.ArcheryWebshop.Category_Product WHERE Product_ID = @ProductId;",
                connection);
            SqlParameter productIdParam = new SqlParameter("@ProductId", SqlDbType.Int);
            productIdParam.Value = productId;
            command.Parameters.Add(productIdParam);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}