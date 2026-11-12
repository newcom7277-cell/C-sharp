// Start the app builder. It also loads appsettings.json automatically.
var builder = WebApplication.CreateBuilder(args);

// BINDING (from Step 4): fill ApplicationSettings with values from the JSON section
builder.Services.Configure<ApplicationSettings>(
    builder.Configuration.GetSection("ApplicationSettings")
);

// REGISTER (new line):
// Tell ASP.NET: "when someone needs PingService, create it for them."
// AddSingleton = create only ONE PingService for the whole app life.
// It is fine here because it only reads settings and stores no user data.
builder.Services.AddSingleton<PingService>();

// Finish the setup. After this line, we cannot add more services.
var app = builder.Build();

// Keep the old URL so we can compare
app.MapGet("/", () => "Hello World! changes code ");

// NEW URL: /ping
// (PingService service) = ASP.NET sees this parameter, finds the registered
// PingService, creates it (passing the filled settings box into its constructor)
// and gives it to us. We never write "new PingService(...)".
app.MapGet("/ping", (PingService service) =>
{
    // Call our method and send the text back to the browser (like res.send(...))
    return service.GetMessage();
});

// Start the web server
app.Run();