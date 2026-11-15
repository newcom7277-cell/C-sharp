var builder = WebApplication.CreateBuilder(args);

// BIND the whole "PaymentSettings" section into a PaymentSettings object.
// "?? new PaymentSettings()" = if the section is missing, use an empty box instead of crashing.
var paymentSettings = builder.Configuration
    .GetSection("PaymentSettings")
    .Get<PaymentSettings>() ?? new PaymentSettings();

// REGISTER the filled box (one shared object for the whole app)
builder.Services.AddSingleton(paymentSettings);

// REGISTER the service that uses it
builder.Services.AddSingleton<PaymentService>();

var app = builder.Build();

// ASK the container for PaymentService (it supplies the settings box)
var paymentService = app.Services.GetRequiredService<PaymentService>();

// Test with an amount of 1000
paymentService.CalculateFinalAmount(1000);

app.Run();
/*

Question 7: Payment Configuration System
Objective: Work with multiple configuration properties in a service.
Requirements
• Create a project named PaymentSystem.
• Create PaymentSettings with Currency, TaxPercentage, EnablePayment and MinimumPaymentAmount properties.
• Store the settings in appsettings.json and bind them to PaymentSettings.
• Create PaymentService and inject PaymentSettings.
• Implement CalculateFinalAmount() to calculate tax and the final amount.
• If payments are disabled, display an appropriate message.
• Test different tax percentages and payment settings.
Learning hints
1. Use decimal for monetary values and tax calculations.
2. Bind the complete JSON section to PaymentSettings.
3. Inject the settings into PaymentService through its constructor.
4. Calculate tax as Amount × TaxPercentage / 100.
5. Add a condition to check EnablePayment before processing.
6. Test with different amounts, tax percentages and enabled/disabled values.
Expected output / observation
Currency: INR
Original Amount: 1000
Tax Percentage: 18%
Tax Amount: 180
Final Amount: 1180
Payment Enabled: True
*/