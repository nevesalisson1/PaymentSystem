using Domain.Payments.Models;

namespace Domain.Payments.Repository
{
    public interface IPaymentSlipRepository
    {
        public Task<int> CreatePaymentSlipAsync(PaymentSlip paymentSlip);
        public Task<PaymentSlip?> GetPaymentSlipAsync(int id);
    }
}