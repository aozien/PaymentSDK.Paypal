using RestSharp;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public interface IPaypalProductManager
    {
        Task<IRestResponse<PaypalProduct>> CreateAsync(PaypalProduct product, string prefer = "representation", string paypalRequestId = "PRODUCT-my-testing01");
        Task<IRestResponse<PaypalProduct>> GetAsync(string productId);
        Task<IRestResponse<PaypalProductsPage>> GetListAsync(int pageSize, int page, bool totalRequired);
        Task<IRestResponse<PaypalProduct>> PatchAsync(string productId, List<PatchObject> patchObjects);
    }
}