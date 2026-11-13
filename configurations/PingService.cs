using System.Net.NetworkInformation;

public class PingService
{
    private readonly PingSettings _settings;
    private readonly ILogger<PingService> _logger;


    public PingService(PingSettings s, ILogger<PingService> l)
    {
        _settings=s;
        _logger=l;
    }
    public void LogInterval()
    {
        //  _
        _logger.LogInformation("Ping Interval : {Interval } second ",_settings.PingInterval);
    }

}