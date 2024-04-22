using Application.Localidade.AutoMapper;
using Application.Payments.AppServices;
using Domain.Payments.Repository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Domain.Payments.Context.Implementations;
using Infrastructure.Domain.Payments.Context.Interfaces;
using Infrastructure.Domain.Payments.Mapping.Implementations;
using Infrastructure.Domain.Payments.Mapping.Interfaces;
using Infrastructure.Domain.Payments.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class ResolverFactoryPayments
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        // Application Layer
        services.AddScoped<IBankAppService, BankAppService>();
        services.AddScoped<IPaymentSlipAppService, PaymentSlipAppService>();

        // Infrastructure Layer
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<IPaymentSlipRepository, PaymentSlipRepository>();
        services.AddScoped<IBankMapping, BankMapping>();
        services.AddScoped<IPaymentSlipMapping, PaymentSlipMapping>();

        services.AddDbContext<PaymentsPostgresContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var paymentSlipMapping = serviceProvider.GetRequiredService<IPaymentSlipMapping>();
            var bankMapping = serviceProvider.GetRequiredService<IBankMapping>();

            var connectionStrings = configuration.GetSection("ConnectionStrings");

            options.UseNpgsql(connectionStrings["PostgresConnection"]);
        }, ServiceLifetime.Scoped);

        services.AddScoped<IPaymentsContext>(provider => provider.GetService<PaymentsPostgresContext>());
    }
}