using Domain.Payments.Models;
using Infrastructure.Domain.Payments.Mapping.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Domain.Payments.Mapping.Implementations;

public class BankMapping : IBankMapping
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.ToTable("bank");
        
        builder.Property(b => b.Id).HasColumnName("id");
        builder.Property(b => b.BankCode).HasColumnName("bankcode");
        builder.Property(b => b.BankName).HasColumnName("bankname");
        builder.Property(b => b.InterestRate).HasColumnName("interestrate");
    }
}