/*
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

*/


var builder=WebApplication.CreateBuilder(args);

var app=builder.Build();


//  1st way it alswasy return a string 
app.MapGet("/", () => "Hello World! changes code ");

var appName=builder.Configuration["App"];

//  way 2 get value 

//<int> tell c# conver the value to a number  for me so maxuser is real number 1000

int maxUsers=builder.Configuration.GetValue<int>("MaxUsers");

bool enableRegistration =builder.Configuration.GetValue<bool>("EnableRegistration");


Console.WriteLine($"Application Name: {appName}");
Console.WriteLine($"Maximum Users: {maxUsers}");
Console.WriteLine($"Registration Enabled: {enableRegistration}");
// COMPARISON: why GetValue<T> is better for numbers
var maxUsersText = builder.Configuration["MaxUsers"]; // this is the text "100"
Console.WriteLine("Text + 1 = " + maxUsersText + 1);  // joins text: prints 1001
Console.WriteLine("Number + 1 = " + (maxUsers + 1));  // real math: prints 101

// Start the web server
app.Run();