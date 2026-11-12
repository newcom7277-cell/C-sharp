// The "empty box". It has the same names as the JSON keys.
public class DatabaseSettings
{
    // Text value. = "" means start with empty text, not null.
    public string DatabaseName { get; set; } = "";

    // Text value for the server address.
    public string ServerName { get; set; } = "";

    // Whole number value. 1433 from the JSON becomes the number 1433.
    public int Port { get; set; }

    // true or false value.
    public bool EnableEncryption { get; set; }
}