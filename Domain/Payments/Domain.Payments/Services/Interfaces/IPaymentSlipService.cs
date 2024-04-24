using Domain.Payments.Models;

namespace Domain.Payments.Services.Interfaces;

public interface IPaymentSlipService
{
    public decimal CalculatePaymentSlip(PaymentSlip paymentSlip);
}