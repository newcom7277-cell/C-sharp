// The "empty box" with the same names as the JSON keys.
public class PaymentSettings
{
    // Text: INR, USD, etc.
    public string Currency { get; set; } = "";

    // decimal: the right type for money and percentages
    public decimal TaxPercentage { get; set; }

    // true = payments allowed, false = payments blocked
    public bool EnablePayment { get; set; }

    // Smallest amount we accept
    public decimal MinimumPaymentAmount { get; set; }
}