// Encrypt the secrets file
namespace DataLayer;

public class Secrets
{
    //TODO: research as to why secrets works the way it does.
    public string ConnectionString { get; set; } //cannot make private as the program will not be able to load
}