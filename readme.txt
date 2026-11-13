DI and Configuration – Practical Assignments Page 1
DI and Configuration
LEVEL 1 – FUNDAMENTALS
Question 1: Application Configuration Reader
Objective: Understand how to read values from appsettings.json.
Requirements
• Create an ASP.NET Core Web API project named ConfigurationDemo.
• Add ApplicationName, MaxUsers and EnableRegistration properties to appsettings.json.
• Read all three values when the application starts.
• Display the values in the console.
Learning hints
1. Open appsettings.json and add the three configuration keys.
2. Use builder.Configuration to access configuration values.
3. Compare Configuration["Key"] with GetValue<T>("Key").
4. Use suitable C# types: string, int and bool.
5. Print the values using Console.WriteLine().
Expected output / observation
Application Name: ConfigurationDemo
Maximum Users: 100
Registration Enabled: True
Question 2: Employee Management Configuration
Objective: Understand different configuration data types and reading individual values.
Requirements
• Create a project named EmployeeManagement.
• Add CompanyName, MaxEmployees, EnableEmployeeRegistration, WorkingHours and MinimumSalary to appsettings.json.
• Read each value into an appropriately typed C# variable.
• Display all values when the application starts.
• Change the values in appsettings.json and verify the output after restarting.
Learning hints
1. Choose a suitable C# type for each setting.
2. Use GetValue<T>() to read typed values.
3. Check what happens when a configuration key is missing.
4. Try changing a number and a boolean value, then run the application again.
Expected output / observation
Company: Tech Solutions
Maximum Employees: 200
Registration: True
Working Hours: 8
Minimum Salary: 15000
DI and Configuration – Practical Assignments Page 2
Question 3: Database Settings Binding
Objective: Understand configuration binding from a JSON section to a C# class.
Requirements
• Create a project named DatabaseConfiguration.
• Create a DatabaseSettings class with DatabaseName, ServerName, Port and EnableEncryption properties.
• Add a DatabaseSettings section to appsettings.json.
• Bind the JSON section to the DatabaseSettings class.
• Display the values using the bound C# object.
Learning hints
1. Create a folder named Configurations.
2. Add public properties with getters and setters to DatabaseSettings.
3. Use builder.Configuration.GetSection("DatabaseSettings").
4. Explore Get<T>() to bind the section to your class.
5. Check that JSON keys correspond to the C# property names.
Expected output / observation
Database Name: EmployeeDB
Server Name: localhost
Port: 1433
Encryption Enabled: True
Question 4: Notification Service Using Constructor Injection
Objective: Understand constructor injection and service registration.
Requirements
• Create a project named NotificationDemo.
• Create a NotificationService with a SendNotification() method.
• Create a UserService that depends on NotificationService.
• Inject NotificationService into UserService through its constructor.
• Register both services with the DI container.
• Resolve UserService and execute its notification operation when the application starts.
Learning hints
1. Create a Services folder and add both service classes.
2. Add NotificationService as a constructor parameter in UserService.
3. Do not create NotificationService manually inside UserService.
4. Register the services using builder.Services.
5. Use app.Services.GetRequiredService<UserService>() to resolve UserService.
6. Observe when each constructor is executed.
Expected output / observation
User Service Initialized
Notification sent successfully!
DI and Configuration – Practical Assignments Page 3
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
SMS Notification Sent!
DI and Configuration – Practical Assignments Page 4
LEVEL 2 – REAL-WORLD PROBLEMS
Question 6: Ping Monitor System
Objective: Combine configuration, binding and dependency injection.
Requirements
• Create a project named PingMonitor.
• Create a PingSettings class with a PingInterval property.
• Store PingInterval inside a PingSettings section in appsettings.json.
• Bind the configuration to PingSettings and register the settings object with DI.
• Create PingService and inject PingSettings through its constructor.
• Log the ping interval when the application starts.
• Change the interval in appsettings.json and verify the updated value after restarting.
Learning hints
1. Create Configurations/PingSettings.cs and define PingInterval as an integer.
2. Use GetSection("PingSettings") and Get<PingSettings>() to bind the section.
3. Register the resulting settings object with AddSingleton().
4. Register PingService with the DI container.
5. Inject PingSettings and ILogger<PingService> into PingService.
6. Use LogInformation() to display the interval.
Expected output / observation
Ping Interval: 30 seconds
DI and Configuration – Practical Assignments Page 5
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
DI and Configuration – Practical Assignments Page 6
Question 8: Library Management System
Objective: Understand multiple dependencies and communication between services.
Requirements
• Create a project named LibraryManagement.
• Create BookService, NotificationService, MemberService and LibraryService.
• BookService should manage book information; MemberService should manage member information.
• NotificationService should display notifications.
• LibraryService should coordinate the other services.
• Implement BorrowBook() to verify that the book and member exist, confirm borrowing and send a notification.
Learning hints
1. Create separate service classes with clearly defined responsibilities.
2. Use sample lists to store book and member information.
3. Add methods that check whether a book and member exist.
4. Inject the required services into LibraryService.
5. Avoid creating service objects manually with new.
6. Register the services with DI and resolve LibraryService to test borrowing.
7. Test both successful borrowing and cases where the book or member is missing.
Expected output / observation
Checking Book Availability...
Book Found!
Checking Member...
Member Found!
Book Borrowed Successfully!
Notification: Your book has been borrowed.
DI and Configuration – Practical Assignments Page 7
Question 9: Understanding DI Lifetimes
Objective: Understand Transient, Scoped and Singleton service lifetimes.
Requirements
• Create a project named ServiceLifetimeDemo.
• Create TransientService, ScopedService and SingletonService.
• Generate and expose a unique GUID in each service instance.
• Register the services using their respective DI lifetimes.
• Resolve each service multiple times from the root provider where appropriate.
• Create two separate scopes and resolve the services inside each scope.
• Compare the GUID values to identify which instances are reused.
Learning hints
1. Use Guid.NewGuid() to generate an identifier in each service constructor.
2. Expose the identifier through an InstanceId property.
3. Register with AddTransient(), AddScoped() and AddSingleton().
4. Use app.Services.CreateScope() to create separate scopes.
5. Resolve each service more than once within a scope and across scopes.
6. Compare the identifiers and explain the observed behavior.
7. Optional: investigate what happens when a singleton directly depends on a scoped service.
Expected output / observation
Transient: a new instance for each resolution.
Scoped: the same instance within one scope; a new instance in another scope.
Singleton: the same instance throughout the service provider's lifetime.
DI and Configuration – Practical Assignments Page 8
Question 10: Application Logging System
Objective: Combine logging with custom application configuration.
Requirements
• Create a project named LoggingSystem.
• Create LoggingSettings with ApplicationName, EnableLogging and LogLevel properties.
• Store the settings in appsettings.json and bind them to LoggingSettings.
• Create LoggingService and inject LoggingSettings and ILogger<LoggingService>.
• Log application startup information and include the application name.
• If EnableLogging is false, skip the service's custom log messages.
• Explore Information, Warning and Error log levels.
Learning hints
1. Create a configuration class and bind its JSON section.
2. Register the settings object with DI.
3. Inject the settings and ILogger<LoggingService> through the constructor.
4. Use LogInformation(), LogWarning() and LogError().
5. Use a condition to control custom log messages.
6. Remember that EnableLogging in your class controls your custom service messages, not automatically all framework
logging.
Expected output / observation
Application: LoggingSystem
Logging Enabled: True
Application started successfully.
DI and Configuration – Practical Assignments Page 9
LEVEL 3 – ADVANCED
Question 11: Order Processing System
Objective: Build a system with multiple interconnected services.
Requirements
• Create a project named OrderProcessing.
• Create OrderService, InventoryService, PaymentService and EmailService.
• Create an Order model containing OrderId, ProductName, Quantity and Price.
• When an order is placed, check stock availability, process payment, update inventory and send an email confirmation.
• If inventory is insufficient, reject the order.
• If payment fails, do not update inventory.
Learning hints
1. Create an Order model and separate service classes.
2. Give each service one clear responsibility.
3. Inject the required services into OrderService.
4. Use return values to communicate whether inventory and payment operations succeeded.
5. Implement the workflow in the correct order.
6. Only update inventory after successful payment.
7. Test successful orders, insufficient stock and failed payments.
Expected output / observation
Order Processing Started...
Checking Inventory... Stock Available!
Processing Payment... Payment Successful!
Updating Inventory... Inventory Updated!
Sending Email... Confirmation Email Sent!
Order Completed Successfully!
DI and Configuration – Practical Assignments Page 10
Question 12: Environment-Specific Configuration
Objective: Understand Development and Production configuration files.
Requirements
• Create a project named EnvironmentConfiguration.
• Add appsettings.json, appsettings.Development.json and appsettings.Production.json.
• Store common settings in appsettings.json and override selected values in the environment-specific files.
• Create an ApplicationSettings class and bind the configuration.
• Display the current environment name and the loaded configuration values.
• Run the application in Development and Production environments and compare the output.
Learning hints
1. Understand the ASPNETCORE_ENVIRONMENT variable.
2. Explore the default configuration loading behavior of WebApplication.CreateBuilder(args).
3. Put common values in appsettings.json.
4. Override selected values in the environment-specific JSON files.
5. Read the environment name using builder.Environment.EnvironmentName.
6. Bind settings using GetSection() and Get<T>().
7. Run with dotnet run --environment Development and dotnet run --environment Production.
Expected output / observation
Current Environment: Development
Application Name: DevelopmentApp
Maximum Users: 50
Question 13: Application Settings Using IOptions
Objective: Understand the Options pattern.
Requirements
• Create a project named OptionsPatternDemo.
• Create PingSettings with PingInterval, RetryCount and ServerName properties.
• Store the settings in a PingSettings section in appsettings.json.
• Register the configuration using Configure<PingSettings>().
• Create PingService and inject IOptions<PingSettings>.
• Display the settings through the injected options object.
Learning hints
1. Explore the Microsoft.Extensions.Options namespace.
2. Register the settings with builder.Services.Configure<PingSettings>().
3. Pass the PingSettings configuration section to Configure().
4. Inject IOptions<PingSettings> into PingService.
5. Access the settings through the Value property.
6. Compare this implementation with the direct settings-object injection used in Question 6.
Expected output / observation
Server: Google
Ping Interval: 30
Retry Count: 3
DI and Configuration – Practical Assignments Page 11
Question 14: Multi-Channel Notification System
Objective: Combine DI, configuration binding and the Options pattern.
Requirements
• Create a project named MultiChannelNotification.
• Create NotificationSettings with EnableEmail, EnableSms, SenderEmail and SenderPhone properties.
• Store the settings in appsettings.json and register them using the Options pattern.
• Create EmailNotificationService, SmsNotificationService and NotificationService.
• Inject both channel services and IOptions<NotificationSettings> into NotificationService.
• Send email when EnableEmail is true and SMS when EnableSms is true.
• Skip disabled channels and test all four combinations of enabled and disabled settings.
Learning hints
1. Create a configuration model for the notification settings.
2. Use Configure<NotificationSettings>() to register the options.
3. Keep email and SMS behavior in separate service classes.
4. Inject the two channel services and options into the coordinating service.
5. Use conditional statements to decide which channel methods to call.
6. Test both enabled, only email enabled, only SMS enabled and both disabled.
Expected output / observation
Notification Started...
Email Notification Sent!
SMS Notification Skipped.
Notification Completed!
DI and Configuration – Practical Assignments Page 12
Question 15: Background Ping Monitoring System
Objective: Combine configuration, DI, Options and hosted background services.
Requirements
• Create a project named BackgroundPingMonitor.
• Create PingSettings with PingInterval, ServerName and EnableMonitoring properties.
• Store the settings in appsettings.json and bind them using the Options pattern.
• Create PingBackgroundService that inherits from BackgroundService.
• Inject the required settings and logger into the background service.
• If monitoring is enabled, start monitoring when the application starts.
• Log the server name, wait for the configured interval and log a ping message repeatedly.
• If monitoring is disabled, do not execute the monitoring loop.
• Stop the service gracefully when the application shuts down.
Learning hints
1. Explore BackgroundService and IHostedService.
2. Create a class that inherits from BackgroundService.
3. Override ExecuteAsync(CancellationToken stoppingToken).
4. Inject IOptions<PingSettings> and ILogger<PingBackgroundService>.
5. Access settings through the Value property.
6. Use Task.Delay() with the configured interval and stoppingToken.
7. Use a loop to repeat the monitoring operation while the service is active.
8. Register the service using AddHostedService<PingBackgroundService>().
9. Test both enabled and disabled monitoring, and stop the application to observe cancellation.
Expected output / observation
Background Ping Monitor Started!
Server: Google
Ping Interval: 5 seconds
Pinging Google...
Pinging Google...
Application shutting down...
Background service stopped.