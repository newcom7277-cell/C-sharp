// This class NEEDS NotificationService to do its work.
public class UserService
{
    // Private variable to keep the helper. "readonly" = set once, never changed.
    private readonly NotificationService _notificationService;

    // CONSTRUCTOR INJECTION:
    // We ask for NotificationService here. ASP.NET Core creates it and passes it in.
    // We never write "new NotificationService()" in this class.
    public UserService(NotificationService notificationService)
    {
        // Save the helper so other methods can use it
        _notificationService = notificationService;

        // This line runs when UserService is created
        Console.WriteLine("User Service Initialized");
    }

    // The operation we run at startup
    public void RegisterUser()
    {
        // Use the injected helper
        _notificationService.SendNotification();
    }
}