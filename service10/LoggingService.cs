public class LoggingService
{
    private readonly LoggingSettings _s;

    private readonly ILogger<LoggingService> _l;

    public LoggingService(LoggingSettings ss,ILogger<LoggingService> ll)
    {
        _s=ss;
        _l=ll;
    }

    public void LogStartup()
    {
        if (!_s.EnableLogging)
        {
            return;
        }
        Console.WriteLine("Hey i am from code .. here is prinitng display ");
        _l.LogInformation("Application: {Name}",_s.ApplicationName);
        _l.LogInformation("Logging Enabled :{Enabled}",_s.EnableLogging);
        _l.LogInformation("Application started Successfully");

        _l.LogWarning("This is sample warminig from {Name}",_s.ApplicationName);
        _l.LogError("This is sample eroor from {Name}",_s.ApplicationName);
    }
}