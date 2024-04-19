using Domain.Payments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Domain.Payments.Context.Interfaces;
using Infrastructure.Domain.Payments.Mapping.Interfaces;

namespace Infrastructure.Domain.Payments.Context.Implementations
{
    public class PaymentsPostgresContext : DbContext, IPaymentsContext
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentSlipMapping _paymentSlipMapping;
        private readonly IBankMapping _bankMapping;

        public DbSet<PaymentSlip> PaymentSlips { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public PaymentsPostgresContext(IConfiguration configuration, IPaymentSlipMapping paymentSlipMapping, IBankMapping bankMapping)
        {
            _configuration = configuration;
            _paymentSlipMapping = paymentSlipMapping;
            _bankMapping = bankMapping;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(_paymentSlipMapping);
            modelBuilder.ApplyConfiguration(_bankMapping);
        }

        public new async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}