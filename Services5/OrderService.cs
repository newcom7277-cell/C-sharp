public class OrderService
{
    private readonly EmailService _emailService;
    private readonly SmsService _smsServise;

    public OrderService(EmailService e,SmsService s)
    {
        _emailService=e;
        _smsServise=s;
        
    }
    public void PlaceOrder()
    {
        Console.WriteLine("Order Placed Successfully !");
        _emailService.SendEmail();
        _smsServise.SendSms();
    }
}