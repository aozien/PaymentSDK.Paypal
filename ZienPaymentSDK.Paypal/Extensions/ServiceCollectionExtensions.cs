﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZienPaymentSDK.Paypal.Interfaces;
using ZienPaymentSDK.Paypal.Services;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaypalAPIService(this IServiceCollection services,
        Action<PaypalProviderOptions> configureOptions)
    {
        services.AddScoped<IPaypalAPIServiceFactory, PaypalAPIServiceFactory>();
        services.AddScoped<IPaypalAPIService, PaypalAPIService>();
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }
        else
        {
            services.AddOptions<PaypalProviderOptions>()
            .Configure<IConfiguration>(
                (options, configuration) =>
                    configuration.GetSection("PaymentSDK:Paypal")
                    .Bind(options));
        }
        return services;
    }

}