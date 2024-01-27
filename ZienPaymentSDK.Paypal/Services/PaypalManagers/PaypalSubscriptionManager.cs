using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.Services.PaypalManagers;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace PaymentProvider.Paypal.Services.PaypalSDK
{
    public class PaypalSubscriptionManager : BasePaypalManager, IPaypalSubscriptionManager
    {
        internal PaypalSubscriptionManager(PaypalProviderOptions options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
        : base(options, jsonSerializer, requestAuthenticator) { }

        public PaypalSubscriptionManager(IOptionsSnapshot<PaypalProviderOptions> options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
            : base(options.Value, jsonSerializer, requestAuthenticator)
        {
        }

        public async Task<IRestResponse> CreateAsync(PaypalSubscription subscription, string paypalRequestId = "SUBSCRIPTION-my-testing01")
        {
            var client = GetClient("/v1/billing/subscriptions");
            var request = CreateRequest(Method.POST, paypalRequestId, "representation");
            request.AddJsonBody(subscription);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> PatchAsync(string subscriptionId, List<PatchObject> patchObjects)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId);
            var request = CreateRequest(Method.PATCH);
            request.AddJsonBody(patchObjects);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> GetAsync(string subscriptionId)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId);
            var request = CreateRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> Activate(string subscriptionId)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId + "/activate");
            var request = CreateRequest(Method.POST);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> Cancel(string subscriptionId, CancelSubscription cancel)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId + "/cancel");
            var request = CreateRequest(Method.POST);
            request.AddJsonBody(cancel);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> SuspendAsync(string subscriptionId, CancelSubscription suspend)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId + "/suspend");
            var request = CreateRequest(Method.POST);
            request.AddJsonBody(suspend);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> TransactionsListAsync(string subscriptionId, string startTime, string endTime)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId +
                "/transactions?start_time=" + startTime + "&end_time=" + endTime);
            var request = CreateRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> CaptureAsync(string subscriptionId, CaptureBody capture)
        {
            var client = GetClient("/v1/billing/subscriptions/" + subscriptionId + "/capture");
            var request = CreateRequest(Method.POST);
            request.AddJsonBody(capture);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }
    }
}
