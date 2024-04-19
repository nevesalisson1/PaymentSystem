using Domain.Payments.Models;
using Infrastructure.Domain.Payments.Mapping.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Domain.Payments.Mapping.Implementations;

public class PaymentSlipMapping : IPaymentSlipMapping
{
    public void Configure(EntityTypeBuilder<PaymentSlip> builder)
    {
        builder.ToTable("paymentslip");
        
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.PayerName).HasColumnName("payername");
        builder.Property(p => p.PayerDocument).HasColumnName("payerdocument");
        builder.Property(p => p.BeneficiaryName).HasColumnName("beneficiaryname");
        builder.Property(p => p.BeneficiaryDocument).HasColumnName("beneficiarydocument");
        builder.Property(p => p.Value).HasColumnName("value");
        builder.Property(p => p.DueDate).HasColumnName("duedate");
        builder.Property(p => p.Observation).HasColumnName("observation");
        builder.Property(p => p.BankId).HasColumnName("bankid");

        builder.HasOne(p => p.Bank)
            .WithMany()
            .HasForeignKey(p => p.BankId);
    }
}