using RestSharp;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public interface IPaypalSubscriptionManager
    {
        Task<IRestResponse> Activate(string subscriptionId);
        Task<IRestResponse> Cancel(string subscriptionId, CancelSubscription cancel);
        Task<IRestResponse> CaptureAsync(string subscriptionId, CaptureBody capture);
        Task<IRestResponse> CreateAsync(PaypalSubscription subscription, string paypalRequestId = "SUBSCRIPTION-my-testing01");
        Task<IRestResponse> GetAsync(string subscriptionId);
        Task<IRestResponse> PatchAsync(string subscriptionId, List<PatchObject> patchObjects);
        Task<IRestResponse> SuspendAsync(string subscriptionId, CancelSubscription suspend);
        Task<IRestResponse> TransactionsListAsync(string subscriptionId, string startTime, string endTime);
    }
}