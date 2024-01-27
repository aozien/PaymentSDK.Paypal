using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public abstract class BasePaypalManager
    {
        protected readonly IAuthenticator RequestAuthenticator;

        protected PaypalProviderOptions PaypalOptions { get; }
        protected IRestSerializer JsonSerializer { get; }

        public BasePaypalManager(
            PaypalProviderOptions options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
        {
            PaypalOptions = options;
            JsonSerializer = jsonSerializer;
            RequestAuthenticator = requestAuthenticator;
        }


        protected IRestClient GetClient(string url)
        {
            var client = new RestClient(PaypalOptions.BaseUrl + url)
                                .UseSerializer(() => JsonSerializer);

            client.Authenticator = RequestAuthenticator;
            //new HttpBasicAuthenticator(PaypalOptions.ClientId, PaypalOptions.ClientSecret);
            return client;
        }

        protected IRestRequest CreateRequest(Method method, string requestId = null, string prefer = null)
        {
            var request = new RestRequest(method);
            request.AddHeader("Content-type", "application/json");

            if (prefer != null)
                request.AddHeader("Prefer", "return=" + prefer);

            if (requestId != null)
                request.AddHeader("PayPal-Request-Id", requestId);

            return request;
        }

    }
}
