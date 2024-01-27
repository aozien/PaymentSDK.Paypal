using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public class PaypalPlanManager : BasePaypalManager, IPaypalPlanManager
    {
        internal PaypalPlanManager(PaypalProviderOptions options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
        : base(options, jsonSerializer, requestAuthenticator)
        {
        }
        public PaypalPlanManager(IOptionsSnapshot<PaypalProviderOptions> options,
            IRestSerializer jsonSerializer,
            IAuthenticator requestAuthenticator)
        : base(options.Value, jsonSerializer, requestAuthenticator)
        {
        }

        public async Task<IRestResponse<PaypalPlan>> CreateAsync(PaypalPlan plan, string prefer = "representation", string paypalRequestId = "PLAN-my-testing01")
        {
            var client = GetClient("/v1/billing/plans");
            var request = CreateRequest(Method.POST, paypalRequestId, prefer);
            request.AddJsonBody(plan);
            IRestResponse<PaypalPlan> response = await client.ExecuteAsync<PaypalPlan>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalPlan>> GetAsync(string planId)
        {
            var client = GetClient("/v1/billing/plans/" + planId);
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalPlan> response = await client.ExecuteAsync<PaypalPlan>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalPlansPage>> GetListAsync(string productId, int pageSize, int page, bool totalRequired)
        {
            var client = GetClient($"/v1/billing/plans?product_id={productId}&page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalPlansPage> response = await client.ExecuteAsync<PaypalPlansPage>(request);
            return response;
        }

        public async Task<IRestResponse> PatchAsync(string planId, List<PatchObject> patchObjects)
        {
            var client = GetClient("/v1/billing/plans/" + planId);
            var request = CreateRequest(Method.PATCH);
            request.AddJsonBody(patchObjects);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> ActivateAsync(string planId)
        {
            var client = GetClient("/v1/billing/plans/" + planId + "/activate");
            var request = CreateRequest(Method.POST);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> DeactivateAsync(string planId)
        {
            var client = GetClient("/v1/billing/plans/" + planId + "/deactivate");
            var request = CreateRequest(Method.POST);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> PricingUpdateAsync(string planId, List<PricingScheme> pricingSchemes)
        {
            var client = GetClient("/v1/billing/plans/" + planId + "/update-pricing-schemes");
            var request = CreateRequest(Method.POST);
            request.AddJsonBody(pricingSchemes);
            IRestResponse response = await client.ExecuteAsync(request);
            return response;
        }
    }
}
