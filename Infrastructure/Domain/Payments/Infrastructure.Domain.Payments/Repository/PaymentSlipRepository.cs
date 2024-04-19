using Domain.Payments.Models;
using Domain.Payments.Repository;
using Infrastructure.Domain.Payments.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Payments.Repository
{
    public class PaymentSlipRepository : IPaymentSlipRepository
    {
        private readonly IPaymentsContext _paymentsContext;

        public PaymentSlipRepository(IPaymentsContext paymentsContext)
        {
            _paymentsContext = paymentsContext;
        }

        public async Task<int> CreatePaymentSlipAsync(PaymentSlip paymentSlip)
        {
            _paymentsContext.PaymentSlips.Add(paymentSlip);
            await _paymentsContext.SaveChangesAsync();
            return paymentSlip.Id;
        }

        public async Task<PaymentSlip?> GetPaymentSlipAsync(int id)
        {
            return await _paymentsContext.PaymentSlips
                .Include(p => p.Bank) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}