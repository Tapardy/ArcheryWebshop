using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DataLayer;
public class Database
{
    private string? _connectionString;
    private SqlConnection? _cnn;
    
    private void Connection()
    {
        const string secretsPath = "/Users/yorischarnigg/.microsoft/usersecrets/b57ad032-2a18-4724-b7c0-85fe635013df/secrets.json";
        string secretsJson = File.ReadAllText(secretsPath);
        Secrets? secrets = JsonSerializer.Deserialize<Secrets>(secretsJson);
        _connectionString = secrets?.ConnectionString;
        _cnn = new SqlConnection(_connectionString);
        _cnn.Open();
        
    }
    public void DataValues(List<string> type)
    {
        Connection();
        SqlCommand command = new SqlCommand(
            "SELECT bowType FROM dbi507362.ArcheryWebshop.Category", _cnn); 
        //TODO: create query variable, maybe pass data from controller to x class and then to here 
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string bowType = reader.GetString(0);
            type.Add(bowType);
        }
        _cnn.Close();
    }
}