using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public class PaypalWebhookManager : BasePaypalManager, IPaypalWebhookManager
    {
        internal PaypalWebhookManager(PaypalProviderOptions options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
        : base(options, jsonSerializer, requestAuthenticator) { }

        public PaypalWebhookManager(IOptionsSnapshot<PaypalProviderOptions> options,
        IRestSerializer jsonSerializer,
        IAuthenticator requestAuthenticator)
            : base(options.Value, jsonSerializer, requestAuthenticator)
        {
        }

        public async Task<IRestResponse<PaypalWebhook>> CreateAsync(PaypalWebhook webhookDef, string prefer = "representation", string paypalRequestId = "PRODUCT-my-testing01")
        {
            var client = GetClient("/v1/notifications/webhooks");
            var request = CreateRequest(Method.POST, paypalRequestId, prefer);
            request.AddJsonBody(webhookDef);
            IRestResponse<PaypalWebhook> response = await client.ExecuteAsync<PaypalWebhook>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalWebhook>> GetAsync(string webhookid)
        {
            var client = GetClient("/v1/notifications/webhooks/" + webhookid);
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalWebhook> response = await client.ExecuteAsync<PaypalWebhook>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalWebhookPage>> GetListAsync(int pageSize, int page, bool totalRequired)
        {
            var client = GetClient($"/v1/notifications/webhooks");
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalWebhookPage> response = await client.ExecuteAsync<PaypalWebhookPage>(request);
            return response;
        }


        /// <summary>Verify PayPal Webhook Signature</summary>
        public async Task<bool> VerifyEvent(string requestBodyRaw, Dictionary<string, string> headerDictionary)
        {
            var webhookId = PaypalOptions.WebhookId;

            if (String.IsNullOrWhiteSpace(webhookId)) {
                throw new Exception("Paypal Webhook Id value must be provided to be able to verify webhook events");
            }

            var client = GetClient("/v1/notifications/verify-webhook-signature");
            var request = CreateRequest(Method.POST);
            // !!IMPORTANT!!
            // Without this direct JSON serialization, PayPal WILL ALWAYS return verification_status = "FAILURE".
            // This is probably because the order of the fields are different and PayPal does not sort them. 
            var paypalVerifyRequestJsonString = $@"{{
				""transmission_id"": ""{headerDictionary.GetValueOrDefault("PAYPAL-TRANSMISSION-ID")}"",
				""transmission_time"": ""{headerDictionary.GetValueOrDefault("PAYPAL-TRANSMISSION-TIME")}"",
				""cert_url"": ""{headerDictionary.GetValueOrDefault("PAYPAL-CERT-URL")}"",
				""auth_algo"": ""{headerDictionary.GetValueOrDefault("PAYPAL-AUTH-ALGO")}"",
				""transmission_sig"": ""{headerDictionary.GetValueOrDefault("PAYPAL-TRANSMISSION-SIG")}"",
				""webhook_id"": ""{webhookId}"",
				""webhook_event"": {requestBodyRaw}
				}}";

            request.Body = new RequestBody("application/json", "application/json", paypalVerifyRequestJsonString);
            IRestResponse response = await client.ExecuteAsync(request);
            var verifyWebhookResponse = JsonConvert.DeserializeObject<VerifyWebhookResponse>(response.Content);
            var valid = verifyWebhookResponse?.VerificationStatus == "SUCCESS" == true;
            return valid;
        }

    }
}
