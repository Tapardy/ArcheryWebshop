namespace WebshopClassLibrary;
using Microsoft.Data.SqlClient;
using System.Text.Json;

public class Database
{
    private string connectionString;
    private SqlConnection cnn;
    
    public Database()
    {
    }

    private void Connection()
    {
        string secretsPath =
            "/Users/yorischarnigg/.microsoft/usersecrets/b57ad032-2a18-4724-b7c0-85fe635013df/secrets.json";
        string secretsJson = File.ReadAllText(secretsPath);
        Secrets? secrets = JsonSerializer.Deserialize<Secrets>(secretsJson);
        connectionString = secrets.ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        
    }
    public void DataValues(List<string> type)
    {
        Connection();
        SqlCommand command = new SqlCommand(
            "SELECT bowType FROM dbi507362.ArcheryWebshop.Category", cnn); //TODO: create query variable, maybe pass data from controller 
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string bowType = reader.GetString(0);
            type.Add(bowType);
        }
        cnn.Close();
    }
}
