// Start the app builder
var builder = WebApplication.CreateBuilder(args);

// REGISTER all three classes (write the MENU).
// Without these lines, the container does not know how to create them.
builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<SmsService>();
builder.Services.AddTransient<OrderService>();

// Finish the setup
var app = builder.Build();

// ASK the container for OrderService (order from the menu).
// The container sees OrderService needs EmailService and SmsService,
// creates both first, then creates OrderService with them inside.
var orderService = app.Services.GetRequiredService<OrderService>();

// Place the order. It calls both helpers inside.
orderService.PlaceOrder();

// Start the web server
app.Run();

/*
Question 5: Multiple Service Dependencies
Objective: Understand how one service can depend on multiple services.
Requirements
• Create a project named ShoppingApplication.
• Create EmailService, SmsService and OrderService.
• Add SendEmail() and SendSms() methods to the notification services.
• Add a PlaceOrder() method to OrderService.
• Inject EmailService and SmsService into OrderService using constructor injection.
• When an order is placed, send both notifications and display an order confirmation.
• Register all three services in the DI container.
Learning hints
1. Create a separate class for each service.
2. Add both notification services as constructor parameters in OrderService.
3. Call their methods from PlaceOrder().
4. Register all services with builder.Services.
5. Resolve OrderService from the DI container and call PlaceOrder().
6. Notice that the container creates and supplies the dependencies.
Expected output / observation
Order Placed Successfully!
Email Notification Sent!
SMS Notification Sent
*/