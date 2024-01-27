using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Interfaces;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services
{
    public class PaypalAPIServiceFactory : IPaypalAPIServiceFactory
    {
        private readonly IRestSerializer _restSerializer;
        private readonly PaypalProviderOptions _options;

        public PaypalAPIServiceFactory(PaypalProviderOptions options, IRestSerializer restSerializer)
        {
            _options = options;
            _restSerializer = restSerializer;
        }

        public PaypalAPIService GetUnitOfWork(
            PaypalProviderOptions paypalOpts)
        {
            return new PaypalAPIService(_restSerializer, paypalOpts);
        }
    }
}
