using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public class PaypalOrdersManager : BasePaypalManager, IPaypalOrdersManager
    {
        public PaypalOrdersManager
           (PaypalProviderOptions options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
        : base(options, jsonSerializer, requestAuthenticator) { }

        public PaypalOrdersManager(IOptionsSnapshot<PaypalProviderOptions> options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
            : base(options.Value, jsonSerializer, requestAuthenticator)
        {
        }

        public async Task<IRestResponse<PaypalOrder>> CreateAsync(PaypalOrder product, string prefer = "representation", string paypalRequestId = "Orders-my-testing01")
        {
            var client = GetClient("/v2/checkout/orders");
            var request = CreateRequest(Method.POST, paypalRequestId, prefer);
            request.AddJsonBody(product);
            IRestResponse<PaypalOrder> response = await client.ExecuteAsync<PaypalOrder>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalOrder>> GetAsync(string orderId)
        {
            var client = GetClient("/v2/checkout/orders/" + orderId);
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalOrder> response = await client.ExecuteAsync<PaypalOrder>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalOrder>> CaptureAsync(string orderId)
        {
            var client = GetClient($"/v2/checkout/orders/{orderId}/capture");
            var request = CreateRequest(Method.POST);
            IRestResponse<PaypalOrder> response = await client.ExecuteAsync<PaypalOrder>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalOrder>> PatchAsync(string orderId, List<PatchObject> patchObjects)
        {
            var client = GetClient("/v2/checkout/orders/" + orderId);
            var request = CreateRequest(Method.PATCH);
            request.AddJsonBody(patchObjects);
            IRestResponse<PaypalOrder> response = await client.ExecuteAsync<PaypalOrder>(request);
            return response;
        }
    }
}
