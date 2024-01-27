using Microsoft.Extensions.DependencyInjection;
using ZienPaymentSDK.Paypal.Interfaces;
using ZienPaymentSDK.Paypal.Services;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaypalAPIService(this IServiceCollection services,
        PaypalProviderOptions options)
    {
        services.AddScoped<IPaypalAPIServiceFactory, PaypalAPIServiceFactory>();

        services.AddScoped<PaypalAPIService>(x => {
            var factory = new PaypalAPIServiceFactory(options, new DefaultJsonSerializer());
            return factory.GetUnitOfWork(options);
        });

        return services;
    }

}