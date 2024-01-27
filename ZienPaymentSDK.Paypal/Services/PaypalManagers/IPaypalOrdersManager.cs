using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;
using RestSharp;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public interface IPaypalOrdersManager
    {
        Task<IRestResponse<PaypalOrder>> CaptureAsync(string orderId);
        Task<IRestResponse<PaypalOrder>> CreateAsync(PaypalOrder product, string prefer = "representation", string paypalRequestId = "Orders-my-testing01");
        Task<IRestResponse<PaypalOrder>> GetAsync(string orderId);
        Task<IRestResponse<PaypalOrder>> PatchAsync(string orderId, List<PatchObject> patchObjects);
    }
}