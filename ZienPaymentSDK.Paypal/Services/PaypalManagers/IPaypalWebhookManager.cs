using RestSharp;
using ZienPaymentSDK.Paypal.Models;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public interface IPaypalWebhookManager
    {
        Task<IRestResponse<PaypalWebhook>> GetAsync(string webhookid);
        Task<IRestResponse<PaypalWebhook>> CreateAsync(PaypalWebhook webhookDef, string prefer = "representation", string paypalRequestId = "PRODUCT-my-testing01");
        Task<bool> VerifyEvent(string json, Dictionary<string, string> headerDictionary);
    }
}