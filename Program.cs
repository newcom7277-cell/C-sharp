// Start the app builder. It loads appsettings.json automatically.
var builder = WebApplication.CreateBuilder(args);

// BINDING in one line:
// GetSection("DatabaseSettings") -> go to that part of the JSON
// Get<DatabaseSettings>()        -> create the box and fill it with those values
var settings = builder.Configuration
    .GetSection("DatabaseSettings")
    .Get<DatabaseSettings>();

// Get<T>() returns null if the section is missing (for example a typo in the name).
// So we check first, to avoid a crash.
if (settings == null)
{
    Console.WriteLine("DatabaseSettings section not found in appsettings.json");
}
else
{
    // Read the values from the object, not from string keys.
    // The editor now shows autocomplete after "settings."
    Console.WriteLine($"Database Name: {settings.DatabaseName}");
    Console.WriteLine($"Server Name: {settings.ServerName}");
    Console.WriteLine($"Port: {settings.Port}");
    Console.WriteLine($"Encryption Enabled: {settings.EnableEncryption}");
}

// Finish the setup and start the server.
var app = builder.Build();
app.Run();