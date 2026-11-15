public class PaymentService
{
    private readonly PaymentSettings _s;

    public PaymentService(PaymentSettings x)
    {
        _s=x;
    }

    public void CalculateFinalAmount(decimal amount)
    {
        if (!_s.EnablePayment)
        {
            Console.WriteLine("Payments are currently disabled.");
            return; // stop here, do nothing else
        }
        if(amount < _s.MinimumPaymentAmount)
        {
            Console.WriteLine($"Amount is below the minimum of {_s.MinimumPaymentAmount} {_s.Currency}.");
            return;
            
        }
        // 3. Tax = Amount x TaxPercentage / 100
        decimal taxAmount = amount * _s.TaxPercentage / 100;

        // 4. Final = Amount + Tax
        decimal finalAmount = amount + taxAmount;

        // 5. Show everything
        Console.WriteLine($"Currency: {_s.Currency}");
        Console.WriteLine($"Original Amount: {amount}");
        Console.WriteLine($"Tax Percentage: {_s.TaxPercentage}%");
        Console.WriteLine($"Tax Amount: {taxAmount}");
        Console.WriteLine($"Final Amount: {finalAmount}");
        Console.WriteLine($"Payment Enabled: {_s.EnablePayment}");
    }
}