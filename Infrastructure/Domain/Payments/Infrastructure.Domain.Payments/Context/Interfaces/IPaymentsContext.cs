using Domain.Payments.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Payments.Context.Interfaces
{
    public interface IPaymentsContext
    {
        DbSet<PaymentSlip> PaymentSlips { get; set; }
        DbSet<Bank> Banks { get; set; }

        Task<int> SaveChangesAsync();
    }
}