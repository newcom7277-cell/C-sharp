var builder = WebApplication.CreateBuilder(args);

// BIND: go to the "PingSettings" section and fill a PingSettings object.
// "?? new PingSettings()" means: if the section is missing (null), use an empty box instead of crashing.
var pingSettings = builder.Configuration
    .GetSection("PingSettings")
    .Get<PingSettings>() ?? new PingSettings();

// REGISTER the filled box in DI as a Singleton (one shared object for the whole app).
// We pass the ready object, so the container hands out exactly this one.
builder.Services.AddSingleton(pingSettings);

// REGISTER PingService so the container can create it.
builder.Services.AddSingleton<PingService>();

var app = builder.Build();

// ASK the container for PingService.
// It sees PingService needs PingSettings and ILogger, supplies both, and builds it.
var pingService = app.Services.GetRequiredService<PingService>();

// Log the interval at startup
pingService.LogInterval();

app.Run();