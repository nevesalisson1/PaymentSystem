using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Infrastructure.Domain.Payments.Context.Implementations;
using Infrastructure.Domain.Payments.Mapping.Implementations;

namespace Infrastructure.Domain.Payments.Context.Initializers
{
    public class PostgresDbInitializer : IDesignTimeDbContextFactory<PaymentsPostgresContext>
    {
        public PaymentsPostgresContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PaymentsPostgresContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));

            return new PaymentsPostgresContext(configuration, new PaymentSlipMapping(), new BankMapping());
        }
    }
}