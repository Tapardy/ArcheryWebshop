using System.Text.Json;

namespace DAL
{
    public class Secrets
    {
        private static string _connectionString;

        static Secrets()
        {
            // Load the secrets file
            string secretsFilePath =
                "/Users/yorischarnigg/.microsoft/usersecrets/b57ad032-2a18-4724-b7c0-85fe635013df/secrets.json";
            string secretsJson = File.ReadAllText(secretsFilePath);

            // Decrypt the secrets file if necessary

            // Parse the secrets file
            using (JsonDocument document = JsonDocument.Parse(secretsJson))
            {
                // Extract the connection string
                JsonElement connectionStringElement = document.RootElement.GetProperty("ConnectionString");
                if (connectionStringElement.ValueKind == JsonValueKind.String)
                {
                    _connectionString = connectionStringElement.GetString();
                }
                else
                {
                    throw new Exception("Invalid connection string in secrets.json");
                }
            }
        }

        public static string ConnectionString => _connectionString;
    }
}