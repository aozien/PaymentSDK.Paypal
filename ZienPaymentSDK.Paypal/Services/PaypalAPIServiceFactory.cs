using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Interfaces;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services
{
    public class PaypalAPIServiceFactory : IPaypalAPIServiceFactory
    {
        private readonly IRestSerializer _restSerializer;

        public PaypalAPIServiceFactory(IRestSerializer restSerializer)
        {
            _restSerializer = restSerializer;
        }

        public PaypalAPIService CreateUnitOfWork(
            PaypalProviderOptions paypalOpts)
        {
            return new PaypalAPIService(_restSerializer, paypalOpts);
        }
    }
}
