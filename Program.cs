// Start the app builder
var builder = WebApplication.CreateBuilder(args);

// REGISTER both services in the DI container.
// This tells ASP.NET Core: "you are allowed to create these classes for people who ask."
// AddTransient = a new object each time it is requested (fine for light, stateless classes).
builder.Services.AddTransient<NotificationService>();
builder.Services.AddTransient<UserService>();

// Finish the setup. After this line, no more services can be added.
var app = builder.Build();

// RESOLVE UserService from the container (ask the container for it).
// The container sees that UserService needs NotificationService,
// creates NotificationService first, then creates UserService with it.
var userService = app.Services.GetRequiredService<UserService>();

// Run the operation. It calls NotificationService inside.
userService.RegisterUser();

// Start the web server
app.Run();