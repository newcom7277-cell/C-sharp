// The box with the same names as the JSON keys.
public class LoggingSettings
{
    public string ApplicationName { get; set; } = ""; // text
    public bool EnableLogging { get; set; }           // true = our service may log
    public string LogLevel { get; set; } = "";        // just text here, we only display it
}