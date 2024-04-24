using Domain.Payments.Services.Interfaces;

namespace Domain.Payments.Services.Implementations;

public class PaymentSlipService : IPaymentSlipService
{
    public decimal CalculatePaymentSlip(Models.PaymentSlip paymentSlip)
    {
        int monthsPastDue = CalculateMonthsPastDue(paymentSlip.DueDate);
        decimal totalInterest = CalculateTotalInterest(paymentSlip.Value, paymentSlip.Bank.InterestRate, monthsPastDue);

        paymentSlip.Value += totalInterest;
        return paymentSlip.Value;
    }
    
    private int CalculateMonthsPastDue(DateTime dueDate)
    {
        return ((DateTime.Now.Year - dueDate.Year) * 12) + DateTime.Now.Month - dueDate.Month;
    }

    private decimal CalculateTotalInterest(decimal value, decimal interestRate, int monthsPastDue)
    {
        return value * interestRate * monthsPastDue;
    }
}