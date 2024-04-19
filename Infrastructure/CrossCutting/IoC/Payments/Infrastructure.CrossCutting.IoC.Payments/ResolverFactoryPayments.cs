﻿using Application.Localidade.AutoMapper;
using Application.Payments.AppServices;
using Domain.Payments.Repository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Domain.Payments.Context.Implementations;
using Infrastructure.Domain.Payments.Context.Interfaces;
using Infrastructure.Domain.Payments.Mapping.Implementations;
using Infrastructure.Domain.Payments.Mapping.Interfaces;
using Infrastructure.Domain.Payments.Repository;

public static class ResolverFactoryPayments
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Application Layer
        services.AddScoped<IBankAppService, BankAppService>();
        services.AddScoped<IPaymentSlipAppService, PaymentSlipAppService>();

        // Infrastructure Layer
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<IPaymentSlipRepository, PaymentSlipRepository>();
        services.AddScoped<IPaymentsContext, PaymentsPostgresContext>();
        services.AddScoped<IBankMapping, BankMapping>();
        services.AddScoped<IPaymentSlipMapping, PaymentSlipMapping>();
    }
}