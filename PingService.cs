using Microsoft.Extensions.Options;

public class PingService
{
    private readonly ApplicationSettings _settings;


    public PingService(IOptions<ApplicationSettings> options)
    /*
    IOptions<ApplicationSettings> → Receives configuration.
     options → Parameter name.
    .Value → Gets the actual ApplicationSettings object.
    _settings → Stores that object for use inside the class.

    IOptions<ApplicationSettings> = A way to access your ApplicationSettings configuration object.
    */

    {
        _settings=options.Value;
    }

    public string GetMessage()
    {
        return $"{_settings.ApplicationName} -> Ping from Interval {_settings.PingInterval} second ";
    }
    
}