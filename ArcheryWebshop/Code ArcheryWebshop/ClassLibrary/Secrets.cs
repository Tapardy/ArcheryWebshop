namespace WebshopClassLibrary;
using System.Text.Json;
using System.IO;
// Encrypt the secrets file

public class Secrets
{
    public string ConnectionString { get; set; } //cannot make private as the program will not be able to load
}