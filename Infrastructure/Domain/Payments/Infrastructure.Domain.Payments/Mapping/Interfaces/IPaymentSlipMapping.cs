using Domain.Payments.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Payments.Mapping.Interfaces;

public interface IPaymentSlipMapping : IEntityTypeConfiguration<PaymentSlip>
{
}