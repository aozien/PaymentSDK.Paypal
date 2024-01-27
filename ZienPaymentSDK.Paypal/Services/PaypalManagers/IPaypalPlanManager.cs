using RestSharp;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public interface IPaypalPlanManager
    {
        Task<IRestResponse<PaypalPlan>> CreateAsync(PaypalPlan plan, string prefer = "representation", string paypalRequestId = "PLAN-my-testing01");
        Task<IRestResponse<PaypalPlan>> GetAsync(string planId);
        Task<IRestResponse<PaypalPlansPage>> GetListAsync(string productId, int pageSize, int page, bool totalRequired);
        Task<IRestResponse> ActivateAsync(string planId);
        Task<IRestResponse> DeactivateAsync(string planId);
        Task<IRestResponse> PatchAsync(string planId, List<PatchObject> patchObjects);
        Task<IRestResponse> PricingUpdateAsync(string planId, List<PricingScheme> pricingSchemes);
    }
}