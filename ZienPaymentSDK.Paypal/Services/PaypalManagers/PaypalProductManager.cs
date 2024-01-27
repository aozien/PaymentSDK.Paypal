using RestSharp;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public class PaypalProductManager : BasePaypalManager, IPaypalProductManager
    {
        public PaypalProductManager(PaypalProviderOptions options, IRestSerializer jsonSerializer)
        : base(options, jsonSerializer)
        {

        }
        //public PaypalProductManager(IOptionsSnapshot<PaypalProviderOptions> options,
        //    IRestSerializer jsonSerializer)
        //    : base(options.Value, jsonSerializer)
        //{
        //}

        public async Task<IRestResponse<PaypalProduct>> CreateAsync(PaypalProduct product, string prefer = "representation", string paypalRequestId = "PRODUCT-my-testing01")
        {
            var client = GetClient("/v1/catalogs/products");
            var request = CreateRequest(Method.POST, paypalRequestId, prefer);
            request.AddJsonBody(product);
            IRestResponse<PaypalProduct> response = await client.ExecuteAsync<PaypalProduct>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalProduct>> GetAsync(string productId)
        {
            var client = GetClient("/v1/catalogs/products/" + productId);
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalProduct> response = await client.ExecuteAsync<PaypalProduct>(request);
            return response;
        }
        public async Task<IRestResponse<PaypalProductsPage>> GetListAsync(int pageSize, int page, bool totalRequired)
        {
            var client = GetClient($"/v1/catalogs/products?page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = CreateRequest(Method.GET);
            IRestResponse<PaypalProductsPage> response = await client.ExecuteAsync<PaypalProductsPage>(request);
            return response;
        }

        public async Task<IRestResponse<PaypalProduct>> PatchAsync(string productId, List<PatchObject> patchObjects)
        {
            var client = GetClient("/v1/catalogs/products/" + productId);
            var request = CreateRequest(Method.PATCH);
            request.AddJsonBody(patchObjects);
            IRestResponse<PaypalProduct> response = await client.ExecuteAsync<PaypalProduct>(request);
            return response;
        }

    }
}
