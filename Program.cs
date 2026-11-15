var builder = WebApplication.CreateBuilder(args);

// BIND the JSON section into a LoggingSettings object
var settings = builder.Configuration
    .GetSection("LoggingSettings")
    .Get<LoggingSettings>() ?? new LoggingSettings();

// REGISTER the filled box and the service
builder.Services.AddSingleton(settings);
builder.Services.AddSingleton<LoggingService>();

var app = builder.Build();

// ASK the container for the service and run the startup logs
var loggingService = app.Services.GetRequiredService<LoggingService>();
loggingService.LogStartup();

app.Run();